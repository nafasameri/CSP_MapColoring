using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSP_MapColoring
{
    public partial class Domains : Form
    {
        public Domains()
        {
            InitializeComponent();
            checkedListBox1.Items.AddRange(new object[]{
                Color.AliceBlue,
                Color.Aqua,
                Color.BlueViolet,
                Color.DarkSeaGreen,
                Color.DeepSkyBlue,
                Color.Violet,
                Color.Tomato,
                Color.Teal,
                Color.Thistle,
                Color.Tan,
                Color.Snow,
                Color.SlateBlue,
                Color.Silver,
                Color.SeaGreen,
                Color.Salmon,
            });
        }
    }
}
