using System;

public class Utils
{
	public Utils()
	
		public static bool FormIsOpen(string name)
	{
        var OpenForms = Application.OpenForms.Cast<Form>(); // This is a list of all the open forms
        var IsOpen = OpenForms.Any(q => q.Name == name); // This is a boolean variable that checks if the form is open or not
		return IsOpen;
    }
}
