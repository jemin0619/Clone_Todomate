﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Clone_Todomate.Converters
{
    public class ImageLoaderConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? imagePath = value as string;
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                return Properties.Resources.DefaultUserImage; // 기본 이미지로 대체
            }

            try
            {
                BitmapImage image = new BitmapImage();

                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                }

                image.Freeze(); // 이미지가 스레드에서 안전하게 사용되도록 함
                return image;
            }
            catch(Exception)
            {
                return Properties.Resources.DefaultUserImage; // 기본 이미지로 대체
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
