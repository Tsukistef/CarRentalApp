﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class Utils
{
    public static bool FormIsOpen(string name)
    {
        var OpenForms = Application.OpenForms.Cast<Form>(); // This is a list of all the open forms
        var IsOpen = OpenForms.Any(q => q.Name == name); // This is a boolean variable that checks if the form is open or not
        return IsOpen;
    }

    public static string HashPassword(string password)
    {
        SHA256 sha = SHA256.Create();

        //Convert the input string to a byte array and compute the hash
        byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

        // Create a Stringbuilder to collect the bytes and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data
        // and format each one as a hexadecimal string
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    public static string DefaultHashedPassword()
    {
        SHA256 sha = SHA256.Create();

        //Convert the input string to a byte array and compute the hash
        byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes("Password@123"));

        // Create a Stringbuilder to collect the bytes and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data
        // and format each one as a hexadecimal string
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
}
