using Downgrooves.Mobile.Models;
using Downgrooves.Mobile.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.Input;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Downgrooves.Mobile.ViewModels
{
    public class OtherMusicViewModel : ViewModelBase
    {
        private IEnumerable<Artist> _artists;
        private readonly IReleaseService _releaseService;
        private readonly IArtistService _artistService;
        private int _selectedViewModelIndex;
        private bool _isBusy;

        public OtherMusicViewModel(IPlayerService playerService, IReleaseService releaseService, IArtistService artistService) : base(playerService)
        {
            _releaseService = releaseService;
            _artistService = artistService;
            Task.Run(() => Load());
        }

        public override async Task Load()
        {

            IsBusy = true;
            try
            {
                _artists = await _artistService.GetArtists();
                if (_artists != null)
                {
                    _artists = _artists.Where(x => x.Name == "Eric Rylos" || x.Name == "Evotone").ToList();

                    var aliases = new List<Artist>();

                    foreach (var artist in _artists)
                    {
                        var newArtist = await LoadReleases(artist);
                        aliases.Add(newArtist);
                    }

                    Artists = aliases;
                }

            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message);
                Log.Fatal(ex.StackTrace);
            }
            finally
            {
                IsBusy = false;
            }
            
        }

        public int SelectedViewModelIndex 
        { 
            get => _selectedViewModelIndex; 
            set => SetProperty(ref _selectedViewModelIndex, value); 
        }

        public IEnumerable<Artist> Artists
        {
            get => _artists;
            set => SetProperty(ref _artists, value);
        }

        public bool IsBusy
        {
            get => _isBusy; 
            set => SetProperty(ref _isBusy, value); 
        }

        public ICommand NavigateToReleaseCommand => new RelayCommand<Release>(NavigateToRelease);

        public async Task<Artist> LoadReleases(Artist artist)
        {
            ObservableCollection<Release> releases = new ObservableCollection<Release>();

            try
            {
                var releasesList = await _releaseService.GetReleases(1, 50, artistId: artist.ArtistId);
                releasesList = releasesList.OrderByDescending(x => x.ReleaseDate);

                if (releasesList.Any())
                    releases = new ObservableCollection<Release>(releasesList);

                artist.Releases = releases;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
            return artist;
        }

        private async void NavigateToRelease(Release release)
        {
            throw new NotImplementedException();
        }

    }
}