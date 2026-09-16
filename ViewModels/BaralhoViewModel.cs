using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JogoCartas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoCartas.ViewModels
{
    public partial class BaralhoViewModel : ObservableObject
    {
        private readonly IBaralhoService _baralhoService;

        [ObservableProperty]
        private string _CardImageUrl;

        [ObservableProperty]
        private string _statusTexto;

        [ObservableProperty]
        private long _cartasRestantes;

        [ObservableProperty]
        private bool _isBusy;

        public BaralhoViewModel(IBaralhoService baralhoService)
        {
            _baralhoService = baralhoService;
            _CardImageUrl = "https://deckofcardsapi.com/static/img/back.png";
            _statusTexto = "Toque no botão para pegar uma carta";
        }

        private bool CanDrawExecute()
        {
            return !IsBusy && CartasRestantes > 0;
        }

        [RelayCommand]

        private async Task PegarCarta()
        {
            IsBusy = true;
            StatusTexto = "Pegando carta...";

            try
            {
                var result = await _baralhoService.DrawCard();
                if (result != null) 
                {
                    CardImageUrl = result.Cards[0].Image;
                    StatusTexto = $"{result.Cards[0].Value} de {result.Cards[0].Suit}";

                    CartasRestantes = result.Remaining;
                }
                else
                {
                    StatusTexto = "Não foi possível pegar uma carta. Tente novamente.";
                }
            }
            catch (Exception)
            {

                StatusTexto = "Erro de conexão";
            }
            finally
            {

            IsBusy = false; 
            }
        }
    }
}
