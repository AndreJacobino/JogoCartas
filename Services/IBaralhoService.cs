using Android.Service.QuickAccessWallet;
using JogoCartas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace JogoCartas.Services
{
     public interface IBaralhoService
    {
        string AtualDeckId { get; }
        Task<CardReponse> DrawCard();
        Task<long> InicializaNovoBaralho();
    }

    public class BaralhoService : IBaralhoService
    {
        private readonly HttpClient _httpClient;

        public BaralhoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string AtualDeckId { get; set; }

        public async Task<CardReponse> DrawCard()
        {
            try
            {
                if (string.IsNullOrEmpty(AtualDeckId))
                {
                    await InicializaNovoBaralho();
                }

                var response = await _httpClient.GetAsync($"{AtualDeckId}/draw/?count=1");

                if (response.IsSuccessStatusCode) 
                {
                    var draw = await response.Content.ReadFromJsonAsync<CardReponse>();

                    if (draw != null) 
                    {
                        return draw;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<long> InicializaNovoBaralho()
        {
            try
            {
                var response = await _httpClient.GetAsync("new/shuffle/?deck_count=1");

                if (response.IsSuccessStatusCode) 
                {
                    var baralho = await response.Content.ReadFromJsonAsync<DeckResponse>();

                    if (baralho != null && baralho.Success)
                    {
                        AtualDeckId = baralho.DeckId;
                        return baralho.Remaining;
                    }
                }
                return 0;
            }
            catch (Exception)
            {

                return 0;
            }
        }

    }
}
