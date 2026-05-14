using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

public class MailService
{
    public bool SendMail(
        string destino,
        string asunto,
        string mensaje,
        bool esHtml = true,
        List<string> adjuntos = null,
        List<string> copia = null,
        List<string> copiaOculta = null)
    {
        try
        {
            // Leer configuración
            string smtp = ConfigurationManager.AppSettings["smtp"];
            int puerto = Convert.ToInt32(
                ConfigurationManager.AppSettings["puerto"]);

            string correo =
                ConfigurationManager.AppSettings["correo"];

            string clave =
                ConfigurationManager.AppSettings["clave"];

            bool ssl = Convert.ToBoolean(
                ConfigurationManager.AppSettings["ssl"]);

            // Crear mail
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(correo);
            mail.To.Add(destino);
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = esHtml;

            // CC
            if (copia != null)
            {
                foreach (string item in copia)
                    mail.CC.Add(item);
            }

            // BCC
            if (copiaOculta != null)
            {
                foreach (string item in copiaOculta)
                    mail.Bcc.Add(item);
            }

            // Adjuntos
            if (adjuntos != null)
            {
                foreach (string ruta in adjuntos)
                {
                    if (File.Exists(ruta))
                        mail.Attachments.Add(
                            new Attachment(ruta));
                }
            }

            // SMTP
            SmtpClient client =
                new SmtpClient(smtp, puerto);

            client.Credentials =
                new NetworkCredential(correo, clave);

            client.EnableSsl = ssl;

            client.Send(mail);

            return true;
        }

        catch (SmtpFailedRecipientException ex)
        {
            GuardarLog("Destinatario inválido: " + destino);
            return false;
        }
        catch (SmtpException ex)
        {
            GuardarLog("Error SMTP: " + ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            GuardarLog(ex.Message);
            return false;
        }
    }

    private static void GuardarLog(string error)
    {
        string ruta = "errores_mail.txt";

        File.AppendAllText(
            ruta,
            DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            + " - " + error
            + Environment.NewLine);
    }
}