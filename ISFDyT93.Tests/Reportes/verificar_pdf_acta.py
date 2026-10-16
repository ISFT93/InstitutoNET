"""Verifica los PDFs sintéticos del script Verificar-ActaMesaFinal.ps1.

Requiere pypdf en el entorno de QA, no en la aplicación WinForms.
Uso: python verificar_pdf_acta.py [carpeta de PDFs]
"""
import os
import re
import sys
from pathlib import Path

from pypdf import PdfReader

carpeta = Path(sys.argv[1]) if len(sys.argv) > 1 else Path(os.environ["TEMP"]) / "ISFDyT93-ActaMesaFinal-tests"
for cantidad in (0, 1, 8, 100):
    documento = PdfReader(carpeta / f"acta-{cantidad}.pdf")
    textos = [pagina.extract_text() for pagina in documento.pages]
    alumnos = []
    for pagina, texto in zip(documento.pages, textos):
        assert abs(float(pagina.mediabox.width) - 841.89) < 0.1, "Ancho A4 horizontal"
        assert abs(float(pagina.mediabox.height) - 595.276) < 0.1, "Alto A4 horizontal"
        assert "ACTA VOLANTE" in texto, "Encabezado institucional ausente"
        encontrados = re.findall(r"APELLIDO(\d{3})", texto)
        alumnos.extend(map(int, encontrados))
        if cantidad:
            assert encontrados, "Página vacía o cierre separado de los alumnos"
            assert "Apellido" in texto and "Observaciones" in texto, "Encabezados de tabla no repetidos"
    assert alumnos == list(range(1, cantidad + 1)), "Registros perdidos, duplicados o fuera de orden"
    assert f"Total de alumnos: {cantidad}" in textos[-1]
    assert sum("Firma y aclaración del profesor titular" in t for t in textos) == 1
    assert "Firma y aclaración del profesor titular" in textos[-1], "Cierre dividido"
    if not cantidad:
        assert "No hay alumnos inscriptos" in textos[0]
    print(f"PASS: {cantidad} alumnos, {len(textos)} páginas, sin duplicados, encabezados y cierre correctos.")

texto = "\n".join(p.extract_text() for p in PdfReader(carpeta / "acta-no-disponible.pdf").pages)
assert "Inscripciones no disponibles" in texto
assert "Total de alumnos: no disponible" in texto
assert "Total de alumnos: 0" not in texto
print("PASS: dependencia ausente diferenciada de una mesa sin inscriptos.")
