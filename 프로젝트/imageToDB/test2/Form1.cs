﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Form1 : Form
    {
        private string path = "C:\\Users\\ksg12\\tensorflow.bbang-yolov4-tflite\\tranfered";
        private int AstaticCount;
        private Thread t;
        private bool bThreadDoWorkRun = false;
        double Latitude;
        double Longitude;

        public Form1()
        {
            InitializeComponent();
            AstaticCount = Init();
            //loopRun(staticCount);
        }



        int Init()
        {
            int count = 1;
            int addcount = 0;
            while (true)
            {
                try
                {
                    string path = string.Format("C:\\Users\\ksg12\\tensorflow.bbang-yolov4-tflite\\tranfered\\{0}.jpg", count);
                    Image image = Image.FromFile(path);
                    //pictureBox1.Image = image1;
                    byte[] data = ConvertImagetoBinary(image);
                    string status = "처리필요";
                    string txtpath = string.Format("C:\\Users\\ksg12\\tensorflow.bbang-yolov4-tflite\\tranfered\\{0}.txt", count);
                    
                    //List<Location> locations = new List<Location>();
                    List<string> lines = File.ReadLines(txtpath).ToList();

                    foreach (var line in lines)
                    {
                        string[] element = line.Split(',');

                        Latitude = double.Parse(element[0]);
                        Longitude = double.Parse(element[1]);
                        
                    }

                    using (Pic2Entities db = new Pic2Entities())//WB31Entities 이거만 바꿔주면된다 DB이름 설정할때
                    {
                        MyPicture pic = new MyPicture() { FileName = count.ToString(), Data = data, Status = status, X= Latitude, Y= Longitude  };

                        if (db.MyPictures.Find(count) == null) //기본키 비교하는거라서 애초에 안잡힘.
                        {

                            //여기에 디비에 저장된 FileName 를 비교해 없으면 저장하는 코드가 추가되어야함.

                            db.MyPictures.Add(pic);
                            db.SaveChangesAsync();
                            //MessageBox.Show("성공적으로 저장 되었습니다.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Thread.Sleep(500);
                            addcount++;
                            count++;

                        }
                        else
                        {
                            count++;
                        }
                    }


                }
                catch (Exception ex)
                {
                    if (addcount != 0)
                    {
                        string ms = string.Format("{0}개의 이미지 추가 저장.", addcount);
                        MessageBox.Show(ms);
                    }
                    return count;
                    //this.Close();
                }
                
            }



        }

        //이미지를 바이트로 변환.
        byte[] ConvertImagetoBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }



        void loopRun()
        {
            
            int staticCount = AstaticCount - 1;
            int len = -1;
            int tempc = -1;
           
            while (true)
            {
                if (System.IO.Directory.Exists(path))
                {
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
                    len = di.GetFiles().Length/2;


                }

                //즉 추가 되었을때 
                if (0<len && len != staticCount)
                {
                    tempc = len - staticCount;
                    for (int i = staticCount; i < len; i++)
                    {
                        int count = staticCount + 1;
                        string path = string.Format("C:\\Users\\ksg12\\tensorflow.bbang-yolov4-tflite\\tranfered\\{0}.jpg", count);
                        Image image = Image.FromFile(path);
                        //pictureBox1.Image = image1;
                        byte[] data = ConvertImagetoBinary(image);

                        string status = "처리필요";
                        string txtpath = string.Format("C:\\Users\\ksg12\\tensorflow.bbang-yolov4-tflite\\tranfered\\{0}.txt", count);



                        //List<Location> locations = new List<Location>();
                        List<string> lines = File.ReadLines(txtpath).ToList();

                        foreach (var line in lines)
                        {
                            string[] element = line.Split(',');

                            Latitude = float.Parse(element[0]);
                            Longitude = float.Parse(element[1]);
                            
                        }

                        using (Pic2Entities db = new Pic2Entities())//WB31Entities 이거만 바꿔주면된다 DB이름 설정할때
                        {
                            MyPicture pic = new MyPicture() { FileName = count.ToString(), Data = data, Status = status, X = Latitude, Y = Longitude };

                            if (db.MyPictures.Find(count) == null) //기본키 비교하는거라서 애초에 안잡힘.
                            {

                                //여기에 디비에 저장된 FileName 를 비교해 없으면 저장하는 코드가 추가되어야함.

                                db.MyPictures.Add(pic);
                                db.SaveChangesAsync();
                                MessageBox.Show("성공적으로 저장 되었습니다.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                staticCount++;
                                
                                
                            }
                            else
                            {
                                count++;
                            }
                        }

                    }
                    string temp = string.Format("{0}개의 이미지가 추가되었습니다", tempc);
                    MessageBox.Show(temp);
                }
                Thread.Sleep(3000);



            }
        
        }


       
        //시작
        private void button1_Click(object sender, EventArgs e)
        {
            if (!bThreadDoWorkRun)
            {
                bThreadDoWorkRun = true;
                t = new Thread(new ThreadStart(loopRun));
                t.Start();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!bThreadDoWorkRun)
            {
                bThreadDoWorkRun = true;
                t.Join();
            }
            this.Close();
        }

       
    }
}
