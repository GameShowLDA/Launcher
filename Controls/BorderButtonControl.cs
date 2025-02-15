﻿namespace LauncherNet.Controls
{
  public class BorderButtonControl : Control
  {
    /// <summary>
    /// Спсиок элементов управления.
    /// </summary>
    public enum Choice
    {
      Exit,
      Minimize,
      Maximize,
      Nope
    }

    /// <summary>
    /// Задаёт или возвращает элемент управления.
    /// </summary>
    public Choice ChoiceElement { get; set; }

    /// <summary>
    /// Отрисовка элемента управления.
    /// </summary>
    /// <param name="e">Данные для рисования.</param>
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (ChoiceElement == Choice.Exit)
      {
        int widthRect = this.Width / 4;
        int heightRect = this.Height / 4;
        int locationX = (this.Width - widthRect) / 2;
        int locationY = (this.Height - widthRect) / 2;

        Graphics graphics = e.Graphics;
        graphics.DrawLine(new Pen(this.ForeColor, 1), locationX, locationY, widthRect + locationX, heightRect + locationY);
        graphics.DrawLine(new Pen(this.ForeColor, 1), widthRect + locationX, locationY, locationX, heightRect + locationY);
      }

      else if (ChoiceElement == Choice.Minimize)
      {
        int widthRect = this.Width / 4;
        int locationX = (this.Width - widthRect) / 2;

        Graphics graphics = e.Graphics;
        graphics.DrawLine(new Pen(this.ForeColor, 1), locationX, this.Height / 2 - 1, locationX + widthRect, this.Height / 2 - 1);
      }

      else if (ChoiceElement == Choice.Maximize)
      {
        int widthRect = this.Width / 4;
        int heightRect = this.Height / 4;
        int locationX = (this.Width - widthRect) / 2;
        int locationY = (this.Height - widthRect) / 2 - widthRect / 6;

        Graphics graphics = e.Graphics;
        graphics.DrawRectangle(new Pen(this.ForeColor, 1), locationX, locationY, widthRect, heightRect);
        graphics.FillRectangle(new SolidBrush(this.BackColor), locationX + 1, locationY + 1, widthRect - 1, heightRect - 1);

        locationX = (this.Width - widthRect) / 2 - widthRect / 4;
        locationY = (this.Height - widthRect) / 2;

        graphics.DrawRectangle(new Pen(this.ForeColor, 1), locationX, locationY, widthRect, heightRect);
        graphics.FillRectangle(new SolidBrush(this.BackColor), locationX + 1, locationY + 1, widthRect - 1, heightRect - 1);
      }
    }

    /// <summary>
    /// Задаёт параметры по-умолчанию.
    /// </summary>
    public BorderButtonControl()
    {
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
      DoubleBuffered = true;
      ChoiceElement = Choice.Nope;
      Size = new Size(20, 20);
    }
  }
}
