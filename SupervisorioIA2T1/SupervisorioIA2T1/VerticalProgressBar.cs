using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Objeto personalizado para fazer uma ProgressBar vertical
/// </summary>
public class VerticalProgressBar : ProgressBar
{
    /// <summary>
    /// Construtor da classe
    /// </summary>
    public VerticalProgressBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
    }

    /// <summary>
    /// Sobrescrita do método CreateParams para fazer a barra vertical
    /// </summary>
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            cp.Style |= 0x04;
            return cp;
        }
    }

    /// <summary>
    /// Sobrescrita do método OnPaint para mudar a cor da barra
    /// </summary>
    /// <param name="e">Evento de pintura</param>
    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rec = e.ClipRectangle;
        rec.Width = rec.Width - 4;
        int heightTemp = (int)(rec.Height * ((double)this.Value / this.Maximum)) - 4;
        heightTemp = rec.Height - heightTemp;
        double percentual = (this.Value * 100) / this.Maximum;

        if (ProgressBarRenderer.IsSupported)
        {
            ProgressBarRenderer.DrawVerticalBar(e.Graphics, e.ClipRectangle);
        }

        if (percentual <= 50)
        {
            e.Graphics.FillRectangle(Brushes.ForestGreen, 2, heightTemp, rec.Width, rec.Height);
            return;
        }

        if (percentual <= 75)
        {
            e.Graphics.FillRectangle(Brushes.Yellow, 2, heightTemp, rec.Width, rec.Height);
            return;
        }

        e.Graphics.FillRectangle(Brushes.Red, 2, heightTemp, rec.Width, rec.Height);
    }
}