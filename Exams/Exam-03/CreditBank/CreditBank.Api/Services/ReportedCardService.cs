using CreditBank.Api.DataAccess;
using CreditBank.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditBank.Api.Services
{
    public class ReportedCardService
    {
        private readonly ReportedCardDataAccess _reportedCardDataAccess;

        public ReportedCardService(ReportedCardDataAccess reportedCardDataAccess)
        {
            _reportedCardDataAccess = reportedCardDataAccess ?? throw new ArgumentNullException(nameof(reportedCardDataAccess));
        }

        public async Task<IList<ReportedCard>> GetAllReportedCards()
        {
            return await _reportedCardDataAccess.GetAllReportedCards();
        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            try
            {
                var reportedUsingNetName = await _reportedCardDataAccess.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);
                // Agregar verificaciones o lógica de negocio según sea necesario
                return reportedUsingNetName;
            }
            catch (Exception ex)
            {
                // Manejar excepciones o registrarlas según tus necesidades
                Console.WriteLine("Error en GetAllReportedCardsByIssuingNetworkName: " + ex.Message);
                throw;
            }
        }

        // Otros métodos según sea necesario
    }
}
