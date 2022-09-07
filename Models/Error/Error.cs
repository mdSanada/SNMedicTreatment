using System.Net;

namespace SNMedicTreatment.Models.Error
{
    public class Error
    {
        /// <summary>
        /// Objeto de retorno de erro padrão do aplicativo.
        /// </summary>
        /// <param name="StatusCode">Objeto de status do erro</param>
        /// <param name="Message">Mensagem</param>
        public Error(HttpStatusCode StatusCode, string Message)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
