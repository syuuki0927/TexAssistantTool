using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * 表や図など、設定値を用いるプログラムを起動する前に必ずこのクラスの
 * インスタンスを作成し、初期値をファイルから取得するようにすること
 */
namespace TexAssistantTool
{
    class SettingsData
    {
        private static bool TableLabelSpecified = true;
        private static bool TableCaptionSpecified = true;
        private static bool TableCenteringSpecified = true;
        private static bool TablePositionSpecified = false;
        private static bool TableCaptionPos = true; //true:top  false:bottom
        private static int[] TablePosition = new int[4];

        private static bool FigureLabelSpecified = true;
        private static bool FigureCaptionSpecified = true;
        private static bool FigureCenteringSpecified = true;
        private static bool FigurePositionSpecified = false;
        private static bool FigureCaptionPos = true;    //true:bottom   false:top
        private static int[] FigurePosition = new int[4];



        public bool getTableLabelSpecified()
        {
            return TableLabelSpecified;
        }

        public bool getTableCaptionSpecified()
        {
            return TableCaptionSpecified;
        }

        public bool getTableCenteringSpecified()
        {
            return TableCaptionSpecified;
        }

        public bool getTablePositionSpecified()
        {
            return TablePositionSpecified;
        }

        public bool getTableCaptionPos()
        {
            return TableCaptionPos;
        }

        public int[] getTablePosition()
        {
            return TablePosition;
        }

        public bool getFigureLabelSpecified()
        {
            return FigureLabelSpecified;
        }

        public bool getFigureCaptionSpecified()
        {
            return FigureCaptionSpecified;
        }

        public bool getFigureCenteringSpecified()
        {
            return FigureCenteringSpecified;
        }

        public bool getFigurePositionSpecified()
        {
            return FigurePositionSpecified;
        }

        public bool getFigureCaptionPos()
        {
            return FigureCaptionPos;
        }

        public int[] getFigurePosition()
        {
            return FigurePosition;
        }


        //セッター
        public void setTableLabelSpecified(bool set)
        {
            TableLabelSpecified = set;
        }

        public void setTableCaptionSpecified(bool set)
        {
            TableCaptionSpecified = set;
        }

        public void setTableCenteringSpecified(bool set)
        {
            TableCenteringSpecified = set;
        }

        public void setTablePositionSpecified(bool set)
        {
            TablePositionSpecified = set;
        }

        public void setTableCaptionPos(bool set)
        {
            TableCaptionPos = set;
        }

        public void setTablePosition(int first,int second,int third,int fourth)
        {
            //TablePosition = first*4096+second*256+third*16+fourth;
            TablePosition[0] = first;
            TablePosition[1] = second;
            TablePosition[2] = third;
            TablePosition[3] = fourth;
        }

        public void setFigureLabelSpecified(bool set)
        {
            FigureLabelSpecified = set;
        }

        public void setFigureCaptionSpecified(bool set)
        {
            FigureCaptionSpecified = set;
        }

        public void setFigureCenteringSpecified(bool set)
        {
            FigureCenteringSpecified = set;
        }

        public void setFigurePositionSpecified(bool set)
        {
            FigurePositionSpecified = set;
        }

        public void setFigureCaptionPos(bool set)
        {
            FigureCaptionPos = set;
        }

        public void setFigurePosition(int first, int second, int third, int fourth)
        {
            //FigurePosition = first * 4096 + second * 256 + third * 16 + fourth;
            FigurePosition[0] = first;
            FigurePosition[1] = second;
            FigurePosition[2] = third;
            FigurePosition[3] = fourth;
        }

        public void pLoad()
        {
            using (StreamReader r = new StreamReader(@"setting.txt"))
            {

                string line;
                line = r.ReadLine();
                if (int.Parse(line) == 0) TableLabelSpecified = false;
                else TableLabelSpecified = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) TableCaptionSpecified = false;
                else TableCaptionSpecified = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) TableCenteringSpecified = false;
                else TableCenteringSpecified = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) TablePositionSpecified = false;
                else TablePositionSpecified = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) TableCaptionPos = false;
                else TableCaptionPos = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) FigureLabelSpecified = false;
                else FigureLabelSpecified = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) FigureCaptionSpecified = false;
                else FigureCaptionSpecified = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) FigureCenteringSpecified = false;
                else FigureCenteringSpecified = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) FigurePositionSpecified = false;
                else FigurePositionSpecified = true;

                line = r.ReadLine();
                if (int.Parse(line) == 0) FigureCaptionPos = false;
                else FigureCaptionPos = true;

                for (int i = 0; i < 4; i++)
                {
                    line = r.ReadLine();
                    TablePosition[i] = int.Parse(line);
                }

                for(int i = 0; i < 4;i++)
                {
                    line = r.ReadLine();
                    FigurePosition[i] = int.Parse(line);
                }

            }

        }

        public void pEnd()
        {
            Encoding enc = Encoding.UTF8;
            StreamWriter writer = new StreamWriter(@"setting.txt", false, enc);

            
            if (TableLabelSpecified) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (TableCaptionSpecified) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (TableCenteringSpecified) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (TablePositionSpecified) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (TableCaptionPos) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (FigureLabelSpecified) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (FigureCaptionSpecified) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (FigureCenteringSpecified) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (FigurePositionSpecified) writer.WriteLine("1");
            else writer.WriteLine("0");

            if (FigureCaptionPos) writer.WriteLine("1");
            else writer.WriteLine("0");


            for (int i = 0; i < 4; i++)
            {
                writer.WriteLine(TablePosition[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                writer.WriteLine(FigurePosition[i]);
            }


            writer.Close();


        }
    }
}
