using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TTMSViewWPF.View.Pages
{

    internal class Repertoire
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public DateTime ReleaseDataTime { get; set; }
        public double Duration { get; set; }
        public List<string> Starrings { get; set; }
        public double Price { get; set; }
        public string DetailString { get; set; }
    }


    /// <summary>
    /// RepertoireManagementPage.xaml 的交互逻辑
    /// </summary>
    public partial class RepertoireManagementPage : Page
    {
        private List<Repertoire> _repertoires;
        private List<Image> _images;
        private MainWindow _window;
        private VirtualizingStackPanel vsp;
        public RepertoireManagementPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _window = mainWindow;
            __Init();
        }

        private void __Init()
        {
            _repertoires = new List<Repertoire>
            {
                new Repertoire()
                {
                    ID = 1 ,
                    Name = "一只狗的使命" , 
                    Writer = "莱塞·霍尔斯道姆",
                    ReleaseDataTime = DateTime.Parse("2017-3-3").Date,
                    Starrings = new List<string>(){ "乔什·加德" , "布丽特·罗伯森" , "丹尼斯·奎德" , "佩吉·利普顿" },
                    Duration = 120 ,
                    Price = 48,
                    DetailString = "    影片以汪星人的视角展现狗狗和人类的微妙情感，一只狗狗陪伴小主人长大成人，甚至为他追到了女朋友，" +
                     "后来它年迈死去又转世投胎变成其他性别和类型的汪，第二次轮回狗狗变成了警犬威风凛凛，再次转轮回，" +
                     "又成了陪伴一位单身女青年的小柯基犬。在经历了多次轮回之后，最终回到最初的主人身边。 "
                },
                new Repertoire()
                {
                    ID = 2 ,
                    Name = "大闹天竺" ,
                    Writer = "王宝强",
                    ReleaseDataTime = DateTime.Parse("2017-1-28").Date,
                    Starrings = new List<string>(){ "王宝强" , "白客" , "岳云鹏" ,"柳岩" },
                    Duration = 100 ,
                    Price = 28,
                    DetailString = "    盛唐集团总裁唐宗突然离世并留下遗训,让他的儿子唐森（白客 饰）在穷小子武空（王宝强 饰）的陪同下前往印度寻找遗嘱。在印度巧遇自恋臭美却又忠诚的朱天鹏（岳云鹏 饰）,以及美丽性感却深藏秘密的美女吴静（柳岩 饰）," +
                                   "四人兜兜转转竟结为同盟,而最令四人不解的是为何这次取遗嘱之旅凶险重重,危机四伏,并且遗嘱之所以放在印度，更是隐藏着秘密。"
                },
                new Repertoire()
                {
                    ID = 3 ,
                    Name = "急速追杀" ,
                    Writer = "查德·史塔赫斯基",
                    ReleaseDataTime = DateTime.Parse("2017-2-10").Date,
                    Starrings = new List<string>(){ "基努·里维斯" , "凡夫俗子" , "劳伦斯·菲什伯恩" ,
                        "里卡多·史卡马西奥" , "露比·萝丝" , "布丽姬·穆娜" , "伊恩·麦克夏恩" , "约翰·拉奎查莫" },
                    Duration = 110 ,
                    Price = 34,
                    DetailString = "　　不久之前刚刚经历丧妻之痛的约翰·威克（基努·里维斯 Keanu Reeves 饰），未曾料到磨难与折磨接二连三袭来。他那辆1964年的福特老爷车被一伙俄罗斯小混混盯上，" +
                                   "旋即引来对方入室抢劫，心爱的狗狗被当场杀死，约翰也遭到无情毒打，那辆老爷车自然被对方抢走。" +
                                   "偷车的混混（阿尔菲·艾伦 Alfie Allen 饰）是黑帮大佬维格•塔拉索夫（迈克尔·恩奎斯特 Michael Nyqvist 饰）的儿子，" +
                                   "而维格在听说这件事后显得紧张非常，因为约翰有着令人胆战心惊的身份。他曾是名震江湖的冷血杀手，当年替塔拉索夫杀掉不少难缠的对手，后来却为了妻子金盆洗手。"
                                    +"愤怒至极的约翰拒绝塔拉索夫的调解，他决定单枪匹马展开复仇……"
                },
                new Repertoire()
                {
                    ID = 4 ,
                    Name = "记忆大师" ,
                    Writer = "陈正道",
                    ReleaseDataTime = DateTime.Parse("2017-4-28").Date,
                    Starrings = new List<string>(){ "黄渤" , "徐静蕾" , "段奕宏" + "杨子姗" , "许玮甯" },
                    Duration = 150 ,
                    Price = 25,
                    DetailString = "https://movie.douban.com/subject/25884801/"
                },
                new Repertoire()
                {
                    ID = 5 ,
                    Name = "美女与野兽" ,
                    Writer = "比尔·坎登",
                    ReleaseDataTime = DateTime.Parse("2017-3-17").Date,
                    Starrings = new List<string>(){ "埃玛·沃森", "丹·史蒂文斯", "凯文·克莱恩" },
                    Duration = 125 ,
                    Price = 38,
                    DetailString = "https://movie.douban.com/subject/25900945/"
                },
                new Repertoire()
                {
                    ID = 6 ,
                    Name = "速度与激情8" ,
                    Writer = "F·盖瑞·葛雷",
                    ReleaseDataTime = DateTime.Parse("2017-4-14").Date,
                    Starrings = new List<string>(){ "范·迪塞尔", "道恩·强森" , "米歇尔·罗德里格兹" ,
                        "泰瑞斯·吉布森", "路达克里斯" , "库尔特·拉塞尔"},
                    Duration = 108 ,
                    Price = 34,
                    DetailString = "https://movie.douban.com/subject/26260853/"
                },
                new Repertoire()
                {
                    ID = 7 ,
                    Name = "送葬人" ,
                    Writer = "史黛西·泰托",
                    ReleaseDataTime = DateTime.Parse("2017-1-13").Date,
                    Starrings = new List<string>(){ "道格拉斯·史密斯", "路西恩·拉维斯康", "克莱希达·波讷斯", "费·唐娜薇" },
                    Duration = 96 ,
                    Price = 34,
                    DetailString = "https://movie.douban.com/subject/26685111/"
                },
                new Repertoire()
                {
                    ID = 8 ,
                    Name = "猩球崛起3" ,
                    Writer = "马特·里夫斯",
                    ReleaseDataTime = DateTime.Parse("2017-7-14").Date,
                    Starrings = new List<string>(){ "安迪·塞基斯", "茱蒂·葛瑞儿", "卡伦·科诺沃", "史蒂夫·茨恩" },
                    Duration = 132 ,
                    Price = 44,
                    DetailString = "https://movie.douban.com/subject/25808075/"
                },
                new Repertoire()
                {
                    ID = 9 ,
                    Name = "银河护卫队2" ,
                    Writer = "詹姆斯·昆恩",
                    ReleaseDataTime = DateTime.Parse("2017-5-5").Date,
                    Starrings = new List<string>(){ "克里斯·帕拉","佐伊·索尔达娜","巴帝斯塔","范·迪塞尔","布莱德利·库珀" },
                    Duration = 120 ,
                    Price = 45,
                    DetailString = "https://movie.douban.com/subject/25937854/"
                },
                new Repertoire()
                {
                    ID = 10 ,
                    Name = "异星觉醒" ,
                    Writer = "丹尼尔·伊斯皮诺萨",
                    ReleaseDataTime = DateTime.Parse("2017-5-5").Date,
                    Starrings = new List<string>(){ "杰克·吉伦哈尔 " , "蕾贝卡·弗格森","瑞安雷诺兹" },
                    Duration = 132 ,
                    Price = 42,
                    DetailString = "https://movie.douban.com/subject/26718838/"
                }
            };
            _images = new List<Image>()
            {
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\yzgdsm.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                },
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\dntz.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                },
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\jszs2.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                },
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\jyds.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                },
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\mvyys.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                },
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\sdyjq8.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                },
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\szr.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                },
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\xqjq3.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                },
                new Image()
                {
                   Source = new BitmapImage(new Uri("..\\..\\Asserts\\posters\\yxjq.jpe", UriKind.Relative)),
                   Stretch = Stretch.UniformToFill
                }
            };
            MoviesListView.ItemsSource = _images;
        }

        private void ToLeftButton_OnClick(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 3; i++)
            {
                vsp.LineLeft();
            }
            
        }

        private void ToRightButton_OnClick(object sender, RoutedEventArgs e)
        {
            for (var i = 0; i < 3; i++)
            {
                vsp.LineRight();
            }
        }

        /// <summary>
        /// 选择改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoviesListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = MoviesListView.SelectedIndex;
            if (index == -1) return;
            UpdateMovieInformation(index);
            DetailTextBlock.Text = _repertoires[index].DetailString;
        }

        private void UpdateMovieInformation(int index)
        {
            var movie = _repertoires[index];
            MovieName.Content = movie.Name;
            MovieWriter.Content = movie.Writer;
            MoviePlayTime.Content = movie.Duration;
            MovieReleaseTime.Content = movie.ReleaseDataTime;
            MovieStarring.Content = movie.Starrings.Aggregate(string.Empty, (current, s) => current + s + " ");
        }

        private void MovieListPanel_OnLoaded(object sender, RoutedEventArgs e)
        {
            vsp = (VirtualizingStackPanel) sender;
            vsp.CanHorizontallyScroll = false;
        }
    }
}
