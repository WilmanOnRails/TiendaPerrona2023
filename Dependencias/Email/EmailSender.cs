using Dependencias.Model;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;


namespace Dependencias.Email
{
    public class EmailSender
    {
        private const string email = "tiendaperrona2.0@gmail.com";
        private const string pass = "glnlywzykgjcarfw";
        private string destiny;
        private string html;

        public EmailSender(string SendTo)
        {
            destiny = SendTo;
            html = File.ReadAllText(Directory.GetCurrentDirectory() + @"\html.txt");
            editData();
        }

        public async Task SendEmail()
        {
            MailMessage smg = new(email, destiny, "Factura Tienda Perrona", html);
            smg.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(email, pass);

                await smtp.SendMailAsync(smg);
            }
        }

        public void fillRows(IEnumerable<CarritoScheme> products)
        {
            var strToInsert = "";
            foreach (var product in products)
            {
                strToInsert += @$"<tr>
						<td><span contenteditable>{product.productName}</span></td>
						<td><span contenteditable>{product.productDescription}</span></td>
						<td><span data-prefix>$</span><span contenteditable>{product.productPrice}</span></td>
				    	<td><span contenteditable>{product.quantity}</span></td>
						<td><span data-prefix>$</span><span>{product.quantity * product.productPrice}</span></td>
					</tr>";

            }

            html = Regex.Replace(html, "<meta name=\"editar aqui\">", strToInsert);

            var si = products.Sum(x => x.productPrice * x.quantity);
            strToInsert = $@"<tr>
                    <th><span contenteditable>Total</span></th >
                    <td><span data - prefix>$</ span>< span contenteditable>{si}</span></td>
                </tr>
                <tr>
                    <th><span contenteditable> Impuesto a pagar</ span ></ th >
                    <td><span data - prefix >$</ span >< span contenteditable >{si*0.15m}</span></td>
                </tr>
                <tr>
                    <th>< span contenteditable > Saldo a cancelar</span></th>
                    <td>< span data - prefix >$</ span >< span contenteditable >{si + (si*015)}</span></ t >
                </tr>";
            html = Regex.Replace(html, "<meta name=\"editar final\">", strToInsert);
        }

        public void fillHeader(UserScheme usertoSend)
        {
            var strToInsert = @$"<address contenteditable>
				<p><b>Nombre: {usertoSend.userName}</b></p>
				<p><b>Dirección: {usertoSend.email}</b><br></p>
			</address>";

            html = Regex.Replace(html, "<meta name=\"editar user\">", strToInsert);
        }

        private void editData()
        {
            Random generator = new();
            var iterations = generator.Next(5, 13);
            var numeroFactura = "";

            for (int i = 0; i < iterations; i++)
            {
                var n = generator.Next(0, 3);

                numeroFactura += n % 2 == 0 ? generator.Next(0, 10) : generator.Next(65, 91);
            }

            var strToInsert = $@"<tr>
					<th><span contenteditable>Numero de factura</span></th>
					<td><span contenteditable>{numeroFactura}</span></td>
				</tr>
				<tr>
					<th><span contenteditable>Fecha</span></th>
					<td><span contenteditable>{DateTime.Now.ToString("dd/MM/yy")}</span></td>
				</tr>";

            html = Regex.Replace(html, "<meta name=\"editar datos\">", strToInsert);
        }



    }
}
