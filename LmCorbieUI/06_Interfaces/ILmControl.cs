using LmCorbieUI.Design;
using System;

namespace LmCorbieUI.Interfaces
{
    public interface ILmControl
    {
        event EventHandler<LmPaintEventArgs> CustomPaintBackground;
        event EventHandler<LmPaintEventArgs> CustomPaint;
        event EventHandler<LmPaintEventArgs> CustomPaintForeground;
        
        bool UseCustomBackColor { get; set; }
        bool UseCustomForeColor { get; set; }
        bool UseSelectable { get; set; }
    }
}
