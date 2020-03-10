# How to update editor value based on another editor in Xamarin.Forms DataForm (SfDataForm) ?

You can change the value of editor based on another editor in Xamarin.Forms SfDataForm using the UpdateEditor method.

This following article explains how to populate a DataFormDropDownItem’s ItemsSource based on the selected item of another DataFormDropDownItem, change the visibility of a DataFormItem based on the value of another field, and update value of an editor based on another editor’s value.

https://www.syncfusion.com/kb/11192/how-to-update-editor-value-based-on-another-editor-in-xamarin-forms-dataform-sfdataform 

To achieve these, you need to implement the INotifyPropertyChanged in data object model class and the raise property changed notifier for all the properties.

**C#:** Raise property changed notifier for DataForm’s DataObject property.
``` c#
 (dataForm.DataObject as DataFormModel).PropertyChanged += OnDataObjectPropertyChanged;
```
**Populating the DropDownItem’s ItemsSource based on the selected item of another DropDownItem.**

**C#:** Here, we are changing the ItemsSource of City based on the selected value of Country field.
``` c#
private void OnDataObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
{
      var dataObject = sender as DataFormModel;
      if(e.PropertyName == "Country")
      {
            var country = dataObject.Country;
            var cityDataFormItem = dataForm.ItemManager.DataFormItems["City"];
            (cityDataFormItem as DataFormDropDownItem).ItemsSource = this.GetCityItemsSource(country);
            dataForm.UpdateEditor("City");
      }
}
```
Returns the ItemsSource based on the Country value.
``` c#
private List<City> GetCityItemsSource(String country)
{
      List<City> cities = new List<City>();
      if(country == "USA")
      {
            cities.Add(new City { Code = 1, Name = "New York" });
            cities.Add(new City { Code = 2, Name = "Los angeles" });
            cities.Add(new City { Code = 3, Name = "Houston" });
       }
       else if(country == "UK")
       {
            cities.Add(new City { Code = 1, Name = "Birmingham" });
            cities.Add(new City { Code = 2, Name = "Cambridge" });
            cities.Add(new City { Code = 3, Name = "London" });
       }
       else if (country == "India")
       {
            cities.Add(new City { Code = 1, Name = "Mumbai" });
            cities.Add(new City { Code = 2, Name = "Chennai" });
            cities.Add(new City { Code = 3, Name = "New Delhi" });
       }
       return cities;
}
```
**Output**

![ItemsSourceUpdate](https://github.com/SyncfusionExamples/update-editor-dataform-xamarin/blob/master/ScreenShots/Output1.gif)

**Changing the value of an editor based on the value of another editor**

**C#:** Here, we are changing the value of Age field based on the value of BirthDate field.

``` c#
private void OnDataObjectPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
{
       var dataObject = sender as DataFormModel;
       if (e.PropertyName =="BirthDate" && dataObject.BirthDate != null && dataObject.BirthDate < DateTime.Now)
       {
             dataObject.Age = DateTime.Now.Year - dataObject.BirthDate.Value.Year;
             dataForm.UpdateEditor("Age");
       }
}
```
**Output**

![ChangeValue](https://github.com/SyncfusionExamples/update-editor-dataform-xamarin/blob/master/ScreenShots/Output3.gif)
