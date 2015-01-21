using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace Threadintests
{
    public class TestAwaitUI
    {
        Button button = new Button { Text = "GO"};        
        TextBox results = new TextBox();
    
        public TestAwaitUI ()
	    {
            var panel = new TableLayoutPanel();
            panel.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            panel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;

            panel.Controls.AddRange(new Control[] { button, results});

            button.Click += button_Click;
        }

       async void button_Click(object sender, EventArgs e)
        {
            button.Enabled = false;
           for (int i = 0; i < 5; i++)
            {
                results.Text +=await GetPrimesCount(i * 1000000, 1000000) +
                    "primes between " + (i * 1000000) + " and" + ((i + 1) * 1000000 - 1) +
                    Environment.NewLine;
            }
           button.Enabled = true;
        }

        private Task<int> GetPrimesCount(int start, int count)
        {
            return Task.Run(() =>
                ParallelEnumerable.Range(start, count).Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }

    
}
