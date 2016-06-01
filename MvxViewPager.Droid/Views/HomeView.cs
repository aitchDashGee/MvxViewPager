// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the HomeView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvxViewPager.Core.ViewModels;
using MvxViewPager.Droid.Adapters;
using MvxViewPager.Droid.Views.Fragments;

namespace MvxViewPager.Droid.Views
{
    /// <summary>
    /// Defines the HomeView type.
    /// </summary>
    [Activity(Label = "View for HomeView")]
    public class HomeView : MvxFragmentCompatActivity<HomeViewModel>
    {
        private ViewPager _viewPager;
        private MvxViewPagerFragmentAdapter _adapter;

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.HomeView);

            SupportActionBar.NavigationMode = (int)ActionBarNavigationMode.Tabs;

            var fragments = new List<MvxViewPagerFragmentAdapter.FragmentInfo>
              {
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                  FragmentType = typeof(FirstFragment),
                  Title = "First Fragment",
                  ViewModel = ViewModel.First
                },
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                  FragmentType = typeof(SecondFragment),
                  Title = "Second Fragment",
                  ViewModel = ViewModel.Second
                },
                new MvxViewPagerFragmentAdapter.FragmentInfo
                {
                  FragmentType = typeof(ThirdFragment),
                  Title = "Third Fragment",
                  ViewModel = ViewModel.Third
                }
              };

            _viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            _adapter = new MvxViewPagerFragmentAdapter(SupportFragmentManager, fragments, SupportActionBar, _viewPager);
            _viewPager.Adapter = _adapter;
            _viewPager.AddOnPageChangeListener(_adapter);

        }
    }
}