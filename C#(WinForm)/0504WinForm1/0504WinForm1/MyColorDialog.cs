using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0504WinForm1
{
    public partial class MyColorDialog : Form
    {
        public MyColorDialog()
        {
            InitializeComponent();
        }

        private void MyColorDialog_Load(object sender, EventArgs e)
        {

        }

        //배경색 설정
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.ShowHelp = true;
            //배경색 설정
            if ((Button)sender == button1)
            {
                colorDlg.Color = this.BackColor;
                if (colorDlg.ShowDialog() == DialogResult.OK)
                    this.BackColor = colorDlg.Color;
            }
            else
            //전경색 설정
            {
                colorDlg.Color = this.ForeColor;
                if (colorDlg.ShowDialog() == DialogResult.OK)
                    this.ForeColor = colorDlg.Color;
            }

        }
        private void MyColorDialog_Paint(object sender, PaintEventArgs e)
        {
            Graphics gx = e.Graphics;
            SolidBrush br = new SolidBrush(this.ForeColor);
            Font font = new Font("돋움", 20);

            gx.DrawString("글자색 변경", font, br, 10, 100);
        }
        #region 색상 얻기 버튼

        private Color CommonColorDlg(Color color)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.ShowHelp = true;
            colorDlg.Color = color;//최초 선택되어지는 색상
            if (colorDlg.ShowDialog() == DialogResult.OK)
                return colorDlg.Color;
            else
                return Color.Black;
        }

        //맴버 변수
        Color color = Color.Black;
        private void button3_Click(object sender, EventArgs e)
        {
            //여기서 그린 그림은 무효화 되면 사라지는 그림
            Graphics gx = pictureBox1.CreateGraphics();

            color = CommonColorDlg(color);
            SolidBrush br = new SolidBrush(color);

            gx.FillRectangle(br, pictureBox1.ClientRectangle);
            //RGB값 출력
            textBox1.Text = color.R.ToString();
            textBox2.Text = color.G.ToString();
            textBox3.Text = color.B.ToString();

            gx.Dispose();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {//사라지지않는 그림
            Graphics gx = e.Graphics;
            SolidBrush br = new SolidBrush(color);
            gx.FillRectangle(br, pictureBox1.ClientRectangle);

        }
        #endregion

        #region 사용자 그리기
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.DrawMode = DrawMode.OwnerDrawVariable;

            Array arr = System.Enum.GetValues(typeof(KnownColor));
            KnowChildColor[] frm = new KnowChildColor[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                listBox1.Items.Add(arr.GetValue(i).ToString());

            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics gx = e.Graphics;
            Array arr = System.Enum.GetValues(typeof(KnownColor));

            //L=R Brush =Color;
            //Color 를 Brush 타입으로 형변환
            Brush brush = new SolidBrush(
                Color.FromName(arr.GetValue(e.Index).ToString()));

            gx.DrawString(listBox1.Items[e.Index].ToString(),
                e.Font, brush, e.Bounds, StringFormat.GenericDefault);
        }
        #endregion

        #region  이미지 출력

        //멤버변수
        Image image = null;

        //image를 로딩
        private void button5_Click(object sender, EventArgs e)
        {
            try { 

            image = Image.FromFile("BATMAN.BMP");
                this.groupBox4.Invalidate();
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message, "파일열기 에러");
            }
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            Graphics gh = e.Graphics;
            if (image != null)
                gh.DrawImage(image, 50, 0);
        }
        #endregion

        //불러온 이미지에 글자를 출력하고 저장(저장시 이미지 포맷을 설정)
        private void button6_Click(object sender, EventArgs e)
        {
            //이미지를 불려들여서 이미지에 글자를 출력
            Image imageFile = Image.FromFile("BATMAN.BMP");
            Graphics gx = Graphics.FromImage(imageFile);
            Font font = new Font("돋움", 20);
            Brush brush = Brushes.Pink;

            gx.DrawString(textBox4.Text, font, brush, 10, 10);
            gx.Dispose();

            //그이미지를 저장
            imageFile.Save("BATMAN_SAVE.jpg",
                System.Drawing.Imaging.ImageFormat.Jpeg);

            //저장된것을 불려들여 화면에 출력
            this.image = Image.FromFile("BATMAN_SAVE.jpg");
            groupBox4.Invalidate();  
        }
    }
}
