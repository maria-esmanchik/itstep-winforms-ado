using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using EntityBDBanks;

namespace BanksSearchApp
{
    public partial class MainForm : Form
    {
        GMapControl gMapControl1;
        GMap.NET.WindowsForms.GMapOverlay markersOverlay;
        BanksContext bc;
       // public delegate void MaxValueUSD(double maxShell);

        public class Bank
        {
            public string text;
            public double x;
            public double y;
            public int id;
        }

        List<Bank> banks;        

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }         

        void MainForm_Load(object sender, EventArgs e)
        {
            SetParamsMap();
        }
        
        // ПРИМЕР РАБОТЫ С КАРТОЙ ! 
        // (данный код используйте по своему усмотрению!)
        void SetParamsMap()
        { 
            // Создание элемента, отображающего карту !
            gMapControl1 = new GMapControl();
            // Растягивание элемента на все окно!
            gMapControl1.Dock = DockStyle.Fill;
            // Добавление элемента 
            //this.Controls.Add(gMapControl1);
            this.splitContainer1.Panel2.Controls.Add(gMapControl1);

            // ОБЩИЕ НАСТРОЙКИ КАРТЫ 
            //Указываем, что будем использовать карты OpenStreetMap.
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap;
            // Указываем источник данных карты (выбран: интренети или локальный кэш)
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

           
            //Настройки для компонента GMap.
            gMapControl1.Bearing = 0;
    
      // МАСШТАБИРОВАНИЕ
            //Указываем значение максимального приближения.
            gMapControl1.MaxZoom = 18;

            //Указываем значение минимального приближения.
            gMapControl1.MinZoom = 2;

            //Указываем, что при загрузке карты будет использоваться 
            //16ти кратной приближение.
            gMapControl1.Zoom = 17;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;


  // НАВИГАЦИЯ ПО КАРТЕ 
            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту  помощью правой кнопки мыши. 
            gMapControl1.CanDragMap = true;

            //Указываем что перетаскивание карты осуществляется 
            //с использованием левой клавишей мыши. По умолчанию - правая.
            gMapControl1.DragButton = MouseButtons.Left;

            //Указываем элементу управления, что необходимо при открытии карты
            // прейти по координатам 
            gMapControl1.Position = new GMap.NET.PointLatLng(53.902800, 27.561759);


            // ОТОБРАЖЕНИЕ МАРКЕРОВ НА КАРТЕ            
            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMapControl1.MarkersEnabled = true;

            ////Создаем новый список маркеров, с указанием компонента 
            ////в котором они будут использоваться и названием списка.
            markersOverlay = new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "marker");
            MarkerRed("hi", 53.902752, 27.561294);
            ////Инициализация нового ЗЕЛЕНОГО маркера, с указанием его координат.
            //GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen markerG =
            //    new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(
            //    //Указываем координаты 
            //    new GMap.NET.PointLatLng(53.902542, 27.561781));
            //markerG.ToolTip =
            //    new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);
            ////Текст отображаемый при наведении на маркер.
            //markerG.ToolTipText = "Объект №1";

            ////Инициализация нового КРАСНОГО маркера, с указанием его координат.
            //GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed markerR =
            //    new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed(
            //    //Указываем координаты 
            //    new GMap.NET.PointLatLng(53.902752, 27.561294));
            //markerR.ToolTip =
            //    new GMap.NET.WindowsForms.ToolTips.GMapBaloonToolTip(markerR);
            ////Текст отображаемый при наведении на маркер.
            //markerR.ToolTipText = "oooo";            

            ////Добавляем маркеры в список маркеров.
            ////Зеленый маркер
            //markersOverlay.Markers.Add(markerG);
            ////Красный маркет
            //////markersOverlay.Markers.Add(markerR);

            // СОБЯТИЯ ПО КАРТЕ !
            gMapControl1.MouseClick += gMapControl1_MouseClick;
            // using (bc = new BanksContext())
            banks = new List<Bank>();
            bc = new BanksContext();
            {              
                
                Random rand = new Random();
                for(int i=0; i<=21;i++)
                {
                    var bank = new Bank();
                    double ry = (0.5 - rand.NextDouble()) / 300.0;
                    double rx = (0.5 - rand.NextDouble()) / 300.0;
                    bank.x = 53.902542 + rx;
                    bank.y = 27.561781 + ry;
                    banks.Add(bank);
                }
                foreach (var row in bc.BankDBUSD)
                {
                    if (banks.Count <= row.Id || row.Id < 0)
                        continue;
                    banks[row.Id].text += "USD: " + row.Id.ToString() + "/" + row.Sell.ToString() + "/" + row.Buy.ToString() + " ";
                }
                foreach (var row in bc.BanksDBEUR)
                {
                    if (banks.Count <= row.Id || row.Id < 0) continue;
                    banks[row.Id].text += "EUR: " + row.Id.ToString() + " / " + row.Sell.ToString() + " / " + row.Buy.ToString() + " ";
                }
                foreach (var row in bc.BanksDBRUR)
                {
                    if (banks.Count <= row.Id || row.Id < 0) continue;
                    banks[row.Id].text += "RUR: " + row.Id.ToString() + row.Sell.ToString() + "/" + row.Buy.ToString() + " ";
                }
                //вставить циклы по евро и рублям
                AddBanksOwerl();
            }
            ////Добавляем в компонент, список маркеров.
            gMapControl1.Overlays.Add(markersOverlay);
          
        }

        void MarkerRed(string text, double x, double y)
        {
            //Инициализация нового КРАСНОГО маркера, с указанием его координат.
            GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed markerR =
                new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed(
                //Указываем координаты 
                new GMap.NET.PointLatLng(x,y));
            markerR.ToolTip =
                new GMap.NET.WindowsForms.ToolTips.GMapBaloonToolTip(markerR);
            //Текст отображаемый при наведении на маркер.
            markerR.ToolTipText = text;

            //Красный маркет
            markersOverlay.Markers.Add(markerR);
         
        }

        void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            GMapOverlay markersOverlay = new GMapOverlay(gMapControl1, "NewMarkers");
            GMapMarkerGoogleGreen markerG =  new GMapMarkerGoogleGreen
                                           (new GMap.NET.PointLatLng(Y, X));
           markerG.ToolTip = new GMapRoundedToolTip(markerG);
           markerG.ToolTipText = "Новый объект";
           markersOverlay.Markers.Add(markerG);
           gMapControl1.Overlays.Add(markersOverlay);
        }

        void OutputValue(BankDBUSD record)
        {
            markersOverlay.Markers.Clear();
            var bank = banks[record.Id];
            MarkerRed(bank.text, bank.x, bank.y);
            gMapControl1.Invalidate();
        }

        private void MaxCourseValue_CheckedChanged(object sender, EventArgs e)
        {
            
            double maxSell = bc.BankDBUSD.Max(p => p.Sell);
            var record = bc.BankDBUSD.Where(p => p.Sell == maxSell).First();
            OutputValue(record);
        }

        private void MinCourseValue_CheckedChanged(object sender, EventArgs e)
        {
            double minSell = bc.BankDBUSD.Min(p => p.Sell);
            var record = bc.BankDBUSD.Where(p => p.Sell == minSell).First();
            OutputValue(record);
        }

        private void ShowAllCourses_CheckedChanged(object sender, EventArgs e)
        {
            AddBanksOwerl();
            gMapControl1.Invalidate();
        }

        void AddBanksOwerl()
        {
            markersOverlay.Markers.Clear();
            foreach (var bank in banks)
            {
                MarkerRed(bank.text, bank.x, bank.y);
            }
        }
    }
}
