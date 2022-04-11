using Downgrooves.Mobile.Views;
using Prism.Behaviors;
using Prism.Common;
using Prism.Navigation;
using System;
using Xamarin.Forms;
using Prism.Navigation.TabbedPages;

namespace Downgrooves.Mobile.Behaviors
{
    public class TabbedPageNavigationBehavior : BehaviorBase<TabbedPage>
    {
        private Page CurrentPage;

        protected override void OnAttachedTo(TabbedPage bindable)
        {
            bindable.CurrentPageChanged += this.OnCurrentPageChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(TabbedPage bindable)
        {
            bindable.CurrentPageChanged -= this.OnCurrentPageChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            var newPage = this.AssociatedObject.CurrentPage;

            if (this.CurrentPage != null)
            {
                var parameters = new NavigationParameters();
                if (newPage is Releases)
                {
                    parameters.Add("ArtistId", 1);
                    parameters.Add("IsOriginal", true);
                }
                if (newPage is Remixes)
                {
                    parameters.Add("ArtistId", 1);
                    parameters.Add("IsRemix", true);
                }
                PageUtilities.OnNavigatedFrom(this.CurrentPage, parameters);
                PageUtilities.OnNavigatedFrom(this.CurrentPage, parameters);
                PageUtilities.OnNavigatedTo(newPage, parameters);
            }

            this.CurrentPage = newPage;
        }
    }
}