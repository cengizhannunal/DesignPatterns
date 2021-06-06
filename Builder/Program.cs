using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartPhoneGenerator smartPhoneGenerator = new SmartPhoneGenerator();
            smartPhoneGenerator.Generate(new AppleSmartPhoneBuilder());
            smartPhoneGenerator.Show();

            smartPhoneGenerator.Generate(new SamsungSmartPhoneBuilder());
            smartPhoneGenerator.Show();
            Console.ReadLine();
        }
    }

    //Product
    class SmartPhone
    {
        public string CameraResolution { get; set; }
        public string OS { get; set; }
        public string ScreenSize { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            return $"Kamera Çözünürlüğü:{CameraResolution}, İşletim Sistemi:{OS}, Ekran Boyutu:{ScreenSize}, Rengi:{Color}";
        }
    }

    //Builder
    abstract class Builder
    {
        protected SmartPhone smartPhone;
        public SmartPhone SmartPhone
        {
            get { return smartPhone; }
        }

        public abstract void CameraResolution();
        public abstract void OS();
        public abstract void ScreenSize();
        public abstract void Color();
    }

    //ConcreteBuilder
    class AppleSmartPhoneBuilder : Builder
    {
        public AppleSmartPhoneBuilder()
        {
            smartPhone = new SmartPhone();
        }

        public override void CameraResolution()
        {
            smartPhone.CameraResolution = "12 megapixel";
        }
        public override void Color()
        {
            smartPhone.Color = "Black";
        }
        public override void ScreenSize()
        {
            smartPhone.ScreenSize = "6 inch";
        }
        public override void OS()
        {
            smartPhone.OS = "Ios";
        }
    }

    //ConcreteBuilder
    class SamsungSmartPhoneBuilder : Builder
    {
        public SamsungSmartPhoneBuilder()
        {
            smartPhone = new SmartPhone();
        }
        public override void CameraResolution()
        {
            smartPhone.CameraResolution = "10 megapixel";
        }
        public override void Color()
        {
            smartPhone.Color = "Red";
        }
        public override void ScreenSize()
        {
            smartPhone.ScreenSize = "6 inch";
        }
        public override void OS()
        {
            smartPhone.OS = "Android";
        }
    }

    //Director
    class SmartPhoneGenerator
    {
        Builder _builder;
        public void Generate(Builder builder)
        {
            _builder = builder;
            builder.CameraResolution();
            builder.OS();
            builder.ScreenSize();
            builder.Color();
        }

        public void Show()
        {
           Console.WriteLine(_builder.SmartPhone.ToString());
        }
    }
}
