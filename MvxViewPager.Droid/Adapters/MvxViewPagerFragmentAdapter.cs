using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using FragmentTransaction = Android.App.FragmentTransaction;

namespace MvxViewPager.Droid.Adapters
{
    public class MvxViewPagerFragmentAdapter
    : FragmentPagerAdapter, ViewPager.IOnPageChangeListener, ActionBar.ITabListener
    {
        private readonly ActionBar _actionBar;
        private readonly ViewPager _viewPager;

        public class FragmentInfo
        {
            public string Title { get; set; }
            public Type FragmentType { get; set; }
            public IMvxViewModel ViewModel { get; set; }
        }

        public MvxViewPagerFragmentAdapter(FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments, ActionBar actionBar, ViewPager viewPager)
            : base(fragmentManager)
        {
            _actionBar = actionBar;
            _viewPager = viewPager;
            Fragments = fragments;

            foreach (var fragmentInfo in Fragments)
            {
                _actionBar.AddTab(_actionBar.NewTab().SetText(fragmentInfo.Title).SetTabListener(this));
            }
        }

        public IEnumerable<FragmentInfo> Fragments { get; }

        public override int Count => Fragments.Count();

        public override Fragment GetItem(int position)
        {
            var frag = Fragments.ElementAt(position);
            var fragment = Activator.CreateInstance(frag.FragmentType) as Fragment;
            ((MvxFragment)fragment).DataContext = frag.ViewModel;
            return fragment;
        }

        protected virtual string FragmentJavaName(Type fragmentType)
        {
            var namespaceText = fragmentType.Namespace ?? "";
            if (namespaceText.Length > 0)
                namespaceText = namespaceText.ToLowerInvariant() + ".";
            return namespaceText + fragmentType.Name;
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int p0) { return new Java.Lang.String(Fragments.ElementAt(p0).Title); }

        public void OnPageScrollStateChanged(int state)
        {
        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
        }

        public void OnPageSelected(int position)
        {
            _actionBar.SetSelectedNavigationItem(position);
        }

        public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }

        public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
        {
            _viewPager.SetCurrentItem(tab.Position, true);
        }

        public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
        {
        }
    }
}