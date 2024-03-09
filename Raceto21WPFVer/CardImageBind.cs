using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raceto21WPFVer
{
    public class CardImageBind
    {
        public ObservableCollection<ImageItem> Images { get; set; }

        public CardImageBind()
        {

            Images = new ObservableCollection<ImageItem>
            {
                new ImageItem{ ImagePath = "/Images/AS.png", ID = "AS" },
                new ImageItem{ ImagePath = "/Images/AC.png", ID = "AC"},
                new ImageItem{ ImagePath = "/Images/AH.png", ID = "AH" },
                new ImageItem{ ImagePath = "/Images/AD.png", ID = "AD" },
                new ImageItem{ ImagePath = "/Images/2S.png", ID = "2S" },
                new ImageItem{ ImagePath = "/Images/2H.png", ID = "2H" },
                new ImageItem{ ImagePath = "/Images/2C.png", ID = "2C" },
                new ImageItem{ ImagePath = "/Images/2D.png", ID = "2D" },
                new ImageItem{ ImagePath = "/Images/3S.png", ID = "3S" },
                new ImageItem{ ImagePath = "/Images/3H.png", ID = "3H" },
                new ImageItem{ ImagePath = "/Images/3C.png", ID = "3C" },
                new ImageItem{ ImagePath = "/Images/3D.png", ID = "3D" },
                new ImageItem{ ImagePath = "/Images/4S.png", ID = "4S" },
                new ImageItem{ ImagePath = "/Images/4H.png", ID = "4H" },
                new ImageItem{ ImagePath = "/Images/4D.png", ID = "4D" },
                new ImageItem{ ImagePath = "/Images/4C.png", ID = "4C" },
                new ImageItem{ ImagePath = "/Images/5S.png", ID = "5S" },
                new ImageItem{ ImagePath = "/Images/5H.png", ID = "5H" },
                new ImageItem{ ImagePath = "/Images/5C.png", ID = "5C" },
                new ImageItem{ ImagePath = "/Images/5D.png", ID = "5D" },
                new ImageItem{ ImagePath = "/Images/6S.png", ID = "6S" },
                new ImageItem{ ImagePath = "/Images/6H.png", ID = "6H" },
                new ImageItem{ ImagePath = "/Images/6C.png", ID = "6C" },
                new ImageItem{ ImagePath = "/Images/6D.png", ID = "6D" },
                new ImageItem{ ImagePath = "/Images/7S.png", ID = "7S" },
                new ImageItem{ ImagePath = "/Images/7H.png", ID = "7H" },
                new ImageItem{ ImagePath = "/Images/7C.png", ID = "7C" },
                new ImageItem{ ImagePath = "/Images/7D.png", ID = "7D" },
                new ImageItem{ ImagePath = "/Images/8S.png", ID = "8S" },
                new ImageItem{ ImagePath = "/Images/8H.png", ID = "8H" },
                new ImageItem{ ImagePath = "/Images/8C.png", ID = "8C" },
                new ImageItem{ ImagePath = "/Images/8D.png", ID = "8D" },
                new ImageItem{ ImagePath = "/Images/9S.png", ID = "9S" },
                new ImageItem{ ImagePath = "/Images/9H.png", ID = "9H" },
                new ImageItem{ ImagePath = "/Images/9C.png", ID = "9C" },
                new ImageItem{ ImagePath = "/Images/9D.png", ID = "9D" },
                new ImageItem{ ImagePath = "/Images/10S.png", ID = "10S" },
                new ImageItem{ ImagePath = "/Images/10H.png", ID = "10H" },
                new ImageItem{ ImagePath = "/Images/10C.png", ID = "10C" },
                new ImageItem{ ImagePath = "/Images/10D.png", ID = "10D" },
                new ImageItem{ ImagePath = "/Images/JS.png", ID = "JS" },
                new ImageItem{ ImagePath = "/Images/JH.png", ID = "JH" },
                new ImageItem{ ImagePath = "/Images/JC.png", ID = "JC" },
                new ImageItem{ ImagePath = "/Images/JD.png", ID = "JD" },
                new ImageItem{ ImagePath = "/Images/KS.png", ID = "KS" },
                new ImageItem{ ImagePath = "/Images/KH.png", ID = "KH" },
                new ImageItem{ ImagePath = "/Images/KC.png", ID = "KC" },
                new ImageItem{ ImagePath = "/Images/KD.png", ID = "KD" },
                new ImageItem{ ImagePath = "/Images/QS.png", ID = "QS" },
                new ImageItem{ ImagePath = "/Images/QD.png", ID = "QD" },
                new ImageItem{ ImagePath = "/Images/QH.png", ID = "QH" },
                new ImageItem{ ImagePath = "/Images/QC.png", ID = "QC" },
            };

          


        }


    }
}
