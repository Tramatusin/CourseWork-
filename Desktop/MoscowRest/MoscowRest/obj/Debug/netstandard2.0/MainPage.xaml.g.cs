//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("MoscowRest.MainPage.xaml", "MainPage.xaml", typeof(global::MoscowRest.MainPage))]

namespace MoscowRest {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("MainPage.xaml")]
    public partial class MainPage : global::Xamarin.Forms.TabbedPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::MoscowRest.Pages.PlacesPage placesPage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::MoscowRest.Pages.MapPage mapPage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::MoscowRest.Pages.RecomendationPage recomendationPage;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MainPage));
            placesPage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::MoscowRest.Pages.PlacesPage>(this, "placesPage");
            mapPage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::MoscowRest.Pages.MapPage>(this, "mapPage");
            recomendationPage = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::MoscowRest.Pages.RecomendationPage>(this, "recomendationPage");
        }
    }
}
