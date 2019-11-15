using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINTER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillData();
        }


        int[][] datos_arr = new int[2][];

        private void button1_Click(object sender, EventArgs e)
        {

            if (punto_x.Text != "" && punto_y.Text != "")
            {
                if (button1.Text == "Modificar Puntos")
                {
                    int pos=0;
                    foreach (DataGridViewRow rows in dataGridView1.Rows)
                    {

                        if (rows.Cells[1].Value != null && (rows.Cells[1].Value.ToString() == punto_x.Text))
                        {
                            if (pos != Convert.ToDouble(txt_i.Text))
                            {
                                return;
                            }
                        }
                        pos++;
                    }
                    if (txt_i.Text != "" && Convert.ToDouble(txt_i.Text) < dataGridView1.Rows.Count-1)
                    {
                        dataGridView1.Rows[Convert.ToInt32(txt_i.Text)].Cells[1].Value = punto_x.Text;
                        dataGridView1.Rows[Convert.ToInt32(txt_i.Text)].Cells[2].Value = punto_y.Text;
                    }
                    if (radio_lagrange.Checked)
                    {
                        imprimirPasosLagrange();
                        imprimirPolinomioLagrange();
                    }
                    else if (radio_newgrepro.Checked)
                    {
                        agregarOrdenAGrilla();
                        escribirPolinomioNewGregoryProg();
                    }
                    else if (radio_newgrereg.Checked)
                    {
                        agregarOrdenAGrilla();
                        escribirPolinomioNewGregoryReg();
                    }

                    txt_k.Text = "";
                    lb_k.Text = "";
                }
                else
                {
                    foreach (DataGridViewRow rows in dataGridView1.Rows)
                    {
                        if (rows.Cells[1].Value != null && (rows.Cells[1].Value.ToString() == punto_x.Text))
                        {
                            return;
                        }
                    }
                    string[] row = { (dataGridView1.Rows.Count - 1).ToString(), punto_x.Text, punto_y.Text };
                    dataGridView1.Rows.Add(row);
                    ordenarYverificarGrilla();
                    punto_x.Text = "";
                    punto_y.Text = "";

                    radio_lagrange.Enabled = true;
                    radio_newgrepro.Enabled = true;
                    radio_newgrereg.Enabled = true;
                    button6.Enabled = true;
                }
            }
        }

        void FillData()
        {            
            dataGridView1.Columns.Add("Column", "i");
            dataGridView1.Columns.Add("Column", "x");
            dataGridView1.Columns.Add("Column", "y");
        }
        private void punto_x_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.Length > 0))
            {
                e.Handled = true;
            }
        }

        private void punto_y_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.Length > 0))
            {
                e.Handled = true;
            }
        }

        string imprimirRaiz(int valor)
        {
                if (valor != 0)
                {
                    if (valor > 0)
                    {
                        return "(x-" + Math.Abs(valor) + ")";
                    } else
                    {
                        return "(x+" + Math.Abs(valor) + ")";
                    }
                } else
                {
                    return "x";
                }            
        }


        string intAstringConSigno(int valor1)
        {
            String strval1 = "";

            if (valor1 == 0)
            {
                strval1 = "";
            }
            else
            {
                if (valor1 > 0)
                {
                    strval1 = "+" + valor1.ToString();
                }
                else
                    strval1 = valor1.ToString();
            }
            return strval1;
        }


        string intAstringConSignoInvertido(int valor1)
        {
            String strval1 = "";

            if (valor1 == 0)
            {
                strval1 = "";
            }
            else
            {
                if (valor1 > 0)
                {
                    strval1 = "-"+valor1.ToString();
                }
                else
                    strval1 = "+"+Math.Abs(valor1).ToString();
            }
            return strval1;
        }

        string imprimirDemominador(int valor1 , int valor2)
        {
            return "(" + intAstringConSigno(valor1) + intAstringConSignoInvertido(valor2) + ")";   
        }
        void imprimirPolinomioLagrange()
        {
            String resultado = "";

            int i = 0;
            resultado = "P(x)=";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    int value = Convert.ToInt32(row.Cells[2].Value);
                    if (value < 0)
                    {
                        resultado += "";
                    }
                    else
                    {
                        resultado += "+";
                    }
                    resultado += row.Cells[2].Value + "L" + i + "(x)";
                    i++;
                }
            }
            lb_orden.Text = "Order" + (i-1);
            lb_polinomio.Text = resultado;
        }

        void ordenarYverificarGrilla()
        {
            dataGridView1.Sort(new RowComparer(SortOrder.Ascending));
        }

        private class RowComparer : System.Collections.IComparer
        {
            private static int sortOrderModifier = 1;

            public RowComparer(SortOrder sortOrder)
            {
                if (sortOrder == SortOrder.Descending)
                {
                    sortOrderModifier = -1;
                }
                else if (sortOrder == SortOrder.Ascending)
                {
                    sortOrderModifier = 1;
                }
            }

            public int Compare(object x, object y)
            {
                DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
                DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;
                
                int CompareResult = Convert.ToInt32(DataGridViewRow1.Cells[1].Value)-Convert.ToInt32(DataGridViewRow2.Cells[1].Value);

                if (CompareResult == 0)
                {
                    CompareResult = System.String.Compare(
                        DataGridViewRow1.Cells[0].Value.ToString(),
                        DataGridViewRow2.Cells[0].Value.ToString());
                }
                return CompareResult * sortOrderModifier;
            }
        }

        void imprimirPasosLagrange()
        {
            String resultado = "";
            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int j = 0;
                if (row.Cells[1].Value != null)
                {
                    resultado += "L" + i + "(x)=";
                    foreach (DataGridViewRow row2 in dataGridView1.Rows)
                    {
                        if (i != j && row2.Cells[1].Value != null)
                        {
                            resultado += imprimirRaiz(Convert.ToInt32(row2.Cells[1].Value));
                        }
                        j++;
                    }
                    resultado += "/";
                    j = 0;
                    foreach (DataGridViewRow row2 in dataGridView1.Rows)
                    {
                        if (i != j && row2.Cells[1].Value != null)
                        {
                            resultado += imprimirDemominador(Convert.ToInt32(row.Cells[1].Value), Convert.ToInt32(row2.Cells[1].Value));
                        }
                        j++;
                    }
                    i++;
                    resultado += "\r\n";
                }
            }
            lb_pasos.Text = resultado;
        }

        void calcularKLagrange(int valork)
        {
            double resultadoNumerador = 1;
            double resultadoDenominador = 1;
            double resultado = 0;
            double i = 0;
            lb_k.Text = "L(k)=";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double j = 0;
                if (row.Cells[1].Value != null)
                {
                    foreach (DataGridViewRow row2 in dataGridView1.Rows)
                    {
                        if (i != j && row2.Cells[1].Value != null)
                        {
                            resultadoNumerador = resultadoNumerador * (valork-Convert.ToDouble(row2.Cells[1].Value));
                        }
                        j++;
                    }
                    j = 0;
                    foreach (DataGridViewRow row2 in dataGridView1.Rows)
                    {
                        if (i != j && row2.Cells[1].Value != null)
                        {
                            resultadoDenominador = resultadoDenominador*(Convert.ToDouble(row.Cells[1].Value)- Convert.ToDouble(row2.Cells[1].Value));
                        }
                        j++;
                    }
                    i++;
                    double res = (resultadoNumerador / resultadoDenominador) * Convert.ToDouble(row.Cells[2].Value);
                    lb_k.Text +=  res+ "+";
                    resultado = resultado+(resultadoNumerador/resultadoDenominador)* Convert.ToDouble(row.Cells[2].Value);
                    resultadoNumerador = 1;
                    resultadoDenominador = 1;
                }
            }
            lb_k.Text += " = " + resultado;
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txt_k.Text != "")
            {
                if (radio_lagrange.Checked)
                {
                    calcularKLagrange(Convert.ToInt32(txt_k.Text));
                }
                else if (radio_newgrepro.Checked)
                {
                    calcularKPolinomioNewGregoryProg();
                }
                else if (radio_newgrereg.Checked)
                {
                    calcularKPolinomioNewGregoryReg();
                }
            }
        }

        double diferenciaDividida (double x1, double x2, double y1, double y2)
        {
            return (y2 - y1) / (x2 - x1);
        }

        void agregarOrdenAGrilla()
        {
            lb_pasos.Text = "";
            lb_polinomio.Text = "";
            int j = 0;


            while (dataGridView1.Columns.Count > 3)
                dataGridView1.Columns.RemoveAt(3);

            int orden = 1;
            for (int i = 0; i < dataGridView1.Rows.Count - 2; i++)
            {
                dataGridView1.Columns.Add("Column", "Orden" + orden);


                foreach (DataGridViewRow rowAux in dataGridView1.Rows)
                {
                    if (rowAux.Cells[1].Value != null && dataGridView1.Rows.Count - 1 > j + orden)
                    {
                        double x1 = Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value);
                        double x2 = Convert.ToDouble(dataGridView1.Rows[j + orden].Cells[1].Value);
                        double y1 = Convert.ToDouble(dataGridView1.Rows[j].Cells[orden + 1].Value);
                        double y2 = Convert.ToDouble(dataGridView1.Rows[j + 1].Cells[orden + 1].Value);
                        double resultado = diferenciaDividida(x1, x2, y1, y2);
                        dataGridView1.Rows[j].Cells[orden + 2].Value = resultado;
                    }
                    j++;
                }
                j = 0;
                orden++;
            }

            dataGridView1.Refresh();
            int printOrder = -3;
            int e=0;
            foreach (DataGridViewColumn columnAux in dataGridView1.Columns)
            {
                double sum = 0;
                foreach (DataGridViewRow rowAux in dataGridView1.Rows)
                {
                    if (rowAux.Cells[e].Value != null)
                    sum += Convert.ToDouble(rowAux.Cells[e].Value);
                }
                if (sum == 0)
                {
                    break;
                }
                printOrder++;
                e++;
            }

            lb_orden.Text = "Order"+printOrder;
        }

        void calcularKPolinomioNewGregoryReg()
        {
            lb_k.Text = "P(k)=";

            double kvalue = Convert.ToDouble(txt_k.Text);
            double resultado = maxValueCell(2);
            int i = 0;
            foreach (DataGridViewColumn columnAux in dataGridView1.Columns)
            {
                if (i > 2)
                {
                    double aux = 1;
                    for (int j = 0; j < i - 2; j++)
                    {
                        aux = aux * (kvalue - Convert.ToDouble(dataGridView1.Rows[dataGridView1.Rows.Count - 2 - j].Cells[1].Value));
                    }
                    aux = aux * maxValueCell(i);
                    resultado += aux;
                }
                i++;
            }

            lb_k.Text += resultado.ToString();
        }

        double maxValueCell(int cell)
        {
            int max = 0;
            foreach (DataGridViewRow rowAux in dataGridView1.Rows)
            {
                if (dataGridView1.Rows[max].Cells[cell].Value != null)
                {
                    max++;
                }
            }
            return Convert.ToDouble(dataGridView1.Rows[max-1].Cells[cell].Value);
        }

        void escribirPolinomioNewGregoryReg()
        {
            lb_polinomio.Text = "P(x)=" + maxValueCell(2);
            int i = 0;
            foreach (DataGridViewColumn columnAux in dataGridView1.Columns)
            {
                if (i > 2)
                {
                    if (Convert.ToDouble(maxValueCell(i)) < 0)
                    {
                        lb_polinomio.Text += maxValueCell(i);
                    }
                    else
                    {
                        lb_polinomio.Text += "+" + maxValueCell(i);
                    }
                    for (int j = 0; j < i - 2; j++)
                    {
                        if (Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value) < 0)
                        {
                            lb_polinomio.Text += "(x+" + Math.Abs(Convert.ToDouble(dataGridView1.Rows[dataGridView1.Rows.Count-2-j].Cells[1].Value)) + ")";
                        }
                        else
                        {
                            lb_polinomio.Text += "(x-" + dataGridView1.Rows[dataGridView1.Rows.Count-2- j].Cells[1].Value + ")";
                        }
                    }
                }
                i++;
            }
        }


        void calcularKPolinomioNewGregoryProg()
        {
            lb_k.Text = "P(k)=";

            double kvalue = Convert.ToDouble(txt_k.Text);
            double resultado= Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value);
            int i = 0;
            foreach (DataGridViewColumn columnAux in dataGridView1.Columns)
            {
                if (i > 2)
                {
                    double aux = 1;
                    for (int j = 0; j < i - 2; j++)
                    {
                        aux = aux * (kvalue- Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value));
                    }
                    aux = aux * Convert.ToDouble(dataGridView1.Rows[0].Cells[i].Value);
                    resultado += aux;
                }
                i++;
            }

            lb_k.Text += resultado.ToString();
        }


        void escribirPolinomioNewGregoryProg()
        {
            lb_polinomio.Text = "P(x)=" + dataGridView1.Rows[0].Cells[2].Value.ToString();
            int i = 0;
            foreach (DataGridViewColumn columnAux in dataGridView1.Columns)
            {
                if (i>2)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[0].Cells[i].Value) < 0)
                    {
                        lb_polinomio.Text += dataGridView1.Rows[0].Cells[i].Value;
                    } else
                    {
                        lb_polinomio.Text += "+" + dataGridView1.Rows[0].Cells[i].Value;
                    }
                    for (int j=0; j<i-2; j++)
                    {
                        if (Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value) < 0)
                        {
                            lb_polinomio.Text += "(x+" + Math.Abs(Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value)) + ")";
                        } else
                        {
                            lb_polinomio.Text += "(x-" + dataGridView1.Rows[j].Cells[1].Value + ")";
                        }
                    }
                }
                i++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            limpiarDatos();

            radio_lagrange.Enabled = false;
            radio_newgrepro.Enabled = false;
            radio_newgrereg.Enabled = false;
            radio_lagrange.Checked = false;
            radio_newgrepro.Checked = false;
            radio_newgrereg.Checked = false;
            button7.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            txt_k.Enabled = false;
            txt_i.Visible = false;
            lb_i.Visible = false;
            button1.Text = "Agregar Puntos";
        }

        void limpiarDatos()
        {
            lb_pasos.Text = "";
            lb_polinomio.Text = "";
            lb_k.Text = "";
            txt_k.Text = "";
            lb_orden.Text = "";
            while (dataGridView1.Columns.Count > 3)
                dataGridView1.Columns.RemoveAt(3);
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            txt_k.Enabled = true;
            lb_pasos.Text = "";
            lb_polinomio.Text = "";
            lb_k.Text = "";
            txt_k.Text = "";

            button1.Text = "Modificar Puntos";
            txt_i.Visible = true;
            lb_i.Visible = true;
            if (radio_lagrange.Checked)
            {
                imprimirPasosLagrange();
                imprimirPolinomioLagrange();
            }
            else if (radio_newgrepro.Checked)
            {
                agregarOrdenAGrilla();
                escribirPolinomioNewGregoryProg();
            }
            else if (radio_newgrereg.Checked)
            {
                agregarOrdenAGrilla();
                escribirPolinomioNewGregoryReg();
            }
        }

        private void radio_lagrange_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = true;
        }

        private void radio_newgrepro_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = true;
        }

        private void radio_newgrereg_CheckedChanged(object sender, EventArgs e)
        {
            button7.Enabled = true;
        }

        private void lb_i_Click(object sender, EventArgs e)
        {

        }
    }
}
