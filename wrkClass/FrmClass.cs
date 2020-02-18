using System;
using System.Reflection;
using System.Windows.Forms;
using static wrkClass.ModelClass;

namespace wrkClass
{
    public partial class FrmClass : Form
    {
        //  Criando uma instancia da classe
        WrkClsModel wrkClsA = new WrkClsModel( "Property A1", "Property A2", "Property A3");
        WrkClsModel wrkClsB = new WrkClsModel( "Property B1", "Property B2", "Property B3");

        string s = "abc";
        string t = "mnopqrstuv";

        public FrmClass()
        {
            InitializeComponent();
            this.Text = "Diferença entre atribuição por REFERENCIA e por VALOR";

            //  Salva wrkClsA em wrkClsB
            //      =========================================================================================
            //      Desta forma as Classes A e B fazem referencia a --DIFERENTES-- areas de memoria
            //      ou seja quando vc altera uma NÃO altera a outra
            //
            //          wrkClsB = new WrkClsModel( wrkClsA.P1, wrkClsA.P2, wrkClsA.P3);
            //                                      ou
            //          wrkClsB.P1 = wrkClsA.P1;
            //          wrkClsB.P2 = wrkClsA.P2;
            //          wrkClsB.P3 = wrkClsA.P3;
            //                                      ou
            //          SaveClsAinClsB(wrkClsA, wrkClsB);   //  a função codificada mais abaixo
            //
            //      =========================================================================================
            //      Desta forma as Classes A e B fazem referencia a -----MESMA---- area de memoria
            //      ou seja quando vc altera uma SIM altera a outra. Até porque estamos falando da mesma area
            //
            //          wrkClsB = wrkClsA;
            //      
            //      =========================================================================================


            //wrkClsB = wrkClsA;
            //lblAssign.Text = "wrkClsB = wrkClsA;";

            SaveClsAinClsB(wrkClsA, wrkClsB);

            //wrkClsB.P1 = wrkClsA.P1;
            //wrkClsB.P2 = wrkClsA.P2;
            //wrkClsB.P3 = wrkClsA.P3;
            lblAssign.Text = "wrkClsB.P1 = wrkClsA.P1;";

            s = t;
        }

        private void BtnMove2ClassA_Click( object sender, EventArgs e) {
            wrkClsA.P1 = txtP1A.Text; txtP1A.Text = "";
            wrkClsA.P2 = txtP2A.Text; txtP2A.Text = "";
            wrkClsA.P3 = txtP3A.Text; txtP3A.Text = "";
            s = txtStringS.Text; txtStringS.Text = "";
        }

        private void BtnMove2ClassB_Click( object sender, EventArgs e) {
            wrkClsB.P1 = txtP1B.Text; txtP1B.Text = "";
            wrkClsB.P2 = txtP2B.Text; txtP2B.Text = "";
            wrkClsB.P3 = txtP3B.Text; txtP3B.Text = "";
            t = txtStringT.Text; txtStringT.Text = "";
        }

        private void BtnShowClassA_Click( object sender, EventArgs e) {
            txtP1A.Text = wrkClsA.P1;
            txtP2A.Text = wrkClsA.P2;
            txtP3A.Text = wrkClsA.P3;
            txtStringS.Text = s;
        }

        private void BtnShowClassB_Click( object sender, EventArgs e) {
            txtP1B.Text = wrkClsB.P1;
            txtP2B.Text = wrkClsB.P2;
            txtP3B.Text = wrkClsB.P3;
            txtStringT.Text = t;
        }

        private void SaveClsAinClsB( WrkClsModel A, WrkClsModel B) {    
            //  Busca a property na classe B de mesmo nome da property em A
            //  e move para a property de mesmo nome em B o valor da property em A

            //  Get a List of all public properties in A
            foreach (var pA in A.GetType().GetProperties()) {
                PropertyInfo pB = B.GetType().GetProperty( pA.Name);
                pB.SetValue( B, pA.GetValue(A, null), null);
            };
        }
    }
}