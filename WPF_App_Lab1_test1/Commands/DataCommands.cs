﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace WPF_App_Lab1_test1.Commands
{
    class DataCommands

    {
        public static RoutedCommand Undo { get; set; }
        public static RoutedCommand New{ get; set; }

        public static RoutedCommand Cut { get; set; }
        public static RoutedCommand Search { get; set; }

        public static RoutedCommand Save { get; set; }
        public static RoutedCommand Delete { get; set; }

        static DataCommands() 
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.U, ModifierKeys.Control, "Ctrl+U"));
            Undo = new RoutedCommand("Undo", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.N, ModifierKeys.Control, "Ctrl+N"));
            New = new RoutedCommand("New", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.E, ModifierKeys.Control, "Ctrl+E"));
            Cut = new RoutedCommand("Cut", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));
            Search = new RoutedCommand("Search", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.S, ModifierKeys.Control, "Ctrl+S"));
            Save = new RoutedCommand("Save", typeof(DataCommands), inputs);

            inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.D, ModifierKeys.Control, "Ctrl+D"));
            Delete = new RoutedCommand("Delete", typeof(DataCommands), inputs);
        }
    }
}
