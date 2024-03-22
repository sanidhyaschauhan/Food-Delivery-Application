using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace Project5dll
{
    public class Authentication
    {
        byte[] Key = { 3, 180, 252, 165, 188, 17, 180, 16, 103, 230, 230, 108, 178, 56, 15, 119, 37, 220, 32, 193, 103, 73, 171, 248, 84, 17, 41, 131, 158, 44, 111, 78 };
        byte[] IV = { 245, 219, 250, 195, 132, 162, 104, 226, 55, 245, 157, 254, 100, 203, 89, 28 };

        public string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                var str1 = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public string Decrypt(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);
            Console.WriteLine(fullCipher);
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                var str2 = Key;
                aesAlg.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(fullCipher))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public CaptchaInfo GetCaptchaImage()
        {
            string captchaText = GenerateRandomText(6);
            byte[] captchaBytes = CreateCaptchaImage(captchaText);

            return new CaptchaInfo
            {
                CaptchaImageBase64 = Convert.ToBase64String(captchaBytes),
                CaptchaId = captchaText
            };
        }

        private byte[] CreateCaptchaImage(string captchaText)
        {
            using (Bitmap bitmap = new Bitmap(200, 50))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // Add noise - lines, circles, etc.
                AddNoise(g, bitmap.Width, bitmap.Height);

                // Drawing the CAPTCHA text
                Random rand = new Random();
                for (int i = 0; i < captchaText.Length; i++)
                {
                    int fontSize = rand.Next(18, 24); // Randomize size a bit
                    using (Font font = new Font("Arial", fontSize, FontStyle.Bold))
                    {
                        // Create a brush using a random color
                        Brush textBrush = new SolidBrush(Color.FromArgb(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100)));

                        // Set the position for the text
                        Point charPoint = new Point(20 + i * 30, rand.Next(15, 25));

                        // Rotate text with different angles
                        float charAngle = rand.Next(-35, 35); // Randomize angle a bit
                        g.TranslateTransform(charPoint.X, charPoint.Y);
                        g.RotateTransform(charAngle);
                        g.DrawString(captchaText[i].ToString(), font, textBrush, 0, 0);
                        g.ResetTransform();
                    }
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
        }

        private void AddNoise(Graphics g, int width, int height)
        {
            Random rand = new Random();
            // Add various types of noise - lines, circles, and dots
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(Pens.Gray,
                    rand.Next(width), rand.Next(height),
                    rand.Next(width), rand.Next(height));
            }

            for (int i = 0; i < 30; i++)
            {
                g.DrawEllipse(Pens.Gray,
                    rand.Next(width), rand.Next(height),
                    rand.Next(5, 10), rand.Next(5, 10));
            }

            for (int i = 0; i < 300; i++)
            {
                g.DrawRectangle(Pens.Gray,
                    rand.Next(width), rand.Next(height),
                    1, 1);
            }
        }

        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class CaptchaInfo
    {
        public string CaptchaImageBase64 { get; set; }
        public string CaptchaId { get; set; }
    }
}
