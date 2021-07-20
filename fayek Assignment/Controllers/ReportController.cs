using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using fayek_Assignment.Models;

namespace fayek_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private static Random random = new Random();

        public ReportController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Start(form formm)
        {
            string dir = @"C:\Count";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            string fileName = @"C:\Count\Temp.txt";
            show shows = new show();
           
            {
             
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                     
                    if (formm.file_size != 0)
                    {
                        long l = Convert.ToInt64(formm.file_size);
                         FileInfo fi = new FileInfo(fileName);
                        long filesize = fi.Length / 1024;
                       
                        if (l > filesize)
                        {

                            int integer = random.Next(36752);
                            string integ = integer.ToString();
                            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                            var result = new string(
                                Enumerable.Repeat(chars, 9)
                                          .Select(s => s[random.Next(s.Length)])
                                          .ToArray());
                            float floatran = (float)random.NextDouble();
                            var floatrand = Math.Round(floatran, 2).ToString();

                            if (formm.alphanumeric == false)
                            {
                                result = "";
                            }
                            if (formm.@float == false)
                            {
                                floatrand = "";

                            }
                            if (formm.numeric == false)
                            {
                                integ = "";
                            }

                            String s = integ + "," + result + "," + floatrand;
                            sw.WriteLine(s);

                        }
                        else
                        {
                            shows.stopForSize = true;

                        }
                    }

                    else
                    {
                         int integer = random.Next(36752);
                        string integ = integer.ToString();
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        var result = new string(
                            Enumerable.Repeat(chars, 9)
                                      .Select(s => s[random.Next(s.Length)])
                                      .ToArray());
                        float floatran = (float)random.NextDouble();
                        var floatrand = Math.Round(floatran, 2).ToString();

                        if (formm.alphanumeric == false)
                        {
                            result = "";
                        }
                        if (formm.@float == false)
                        {
                            floatrand = "";

                        }
                        if (formm.numeric == false)
                        {
                            integ = "";
                        }

                        String s = integ + "," + result + "," + floatrand;
                        sw.WriteLine(s);
                         }
                     sw.Close();
                }


            }
            IList<string> AllLine = new List<string>();
          
            shows.intCount = 0;
            shows.FloatCount = 0;
            shows.AlphanumericCount = 0;

            if (System.IO.File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {

                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        AllLine.Add(line);
                    }
                    foreach (var oneLine in AllLine)
                    {
                        // Split authors separated by a comma followed by space  
                        Char[] mychars = { ',', ',' };
                        string[] data = oneLine.Split(mychars);
                        int i = 0;
                        foreach (string onedata in data)
                        {
                            if (i == 0 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.intCount++;
                            }
                            if (i == 1 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.AlphanumericCount++;
                            }
                            if (i == 2 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.FloatCount++;
                            }

                            i++;

                        }

                    }
                    sr.Close();
                }
            }
            return Ok(shows);
              

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Stop()
        { 
            string fileName = @"C:\Count\Temp.txt";
            //Check if the file exists

            show shows = new show();
            IList<string> AllLine = new List<string>();
     

            shows.intCount = 0;
            shows.FloatCount = 0;
            shows.AlphanumericCount = 0;

            if (System.IO.File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {


                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        AllLine.Add(line);
                    }
                    foreach (var oneLine in AllLine)
                    {
                        // Split authors separated by a comma followed by space  
                        Char[] mychars = { ',', ',' };
                        string[] data = oneLine.Split(mychars);
                        int i = 0;
                        foreach (string onedata in data)
                        {
                            if (i == 0 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.intCount++;
                            }
                            if (i == 1 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.AlphanumericCount++;
                            }
                            if (i == 2 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.FloatCount++;
                            }

                            i++;

                        }

                    }

                }
            }

            //      resObject = new ResponseObject { Message = "Counter", Status = "success", Data = shows, HttpStatusCode = HttpStatusCode.OK };

            return Ok(shows);

        }

        [HttpGet("GenerateReport/", Name = "GenerateReport")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Generate()
        {

            string fileName = @"C:\Count\Temp.txt";
            //Check if the file exists

            percentage per = new percentage();
            show shows = new show();
            IList<string> AllLine = new List<string>();
          

            shows.intCount = 0;
            shows.FloatCount = 0;
            shows.AlphanumericCount = 0;
            if (System.IO.File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {

                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        AllLine.Add(line);
                    }
                    foreach (var oneLine in AllLine)
                    {
                        // Split authors separated by a comma followed by space  
                        Char[] mychars = { ',', ',' };
                        string[] data = oneLine.Split(mychars);
                        int i = 0;
                        foreach (string onedata in data)
                        {
                            if (i == 0 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.intCount++;
                            }
                            if (i == 1 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.AlphanumericCount++;
                            }
                            if (i == 2 && !string.IsNullOrEmpty(onedata))
                            {
                                shows.FloatCount++;
                            }

                            i++;

                        }

                    }

                }
            }
            //   var PriceWithtax = price + (price * total / 100);

            int totalCounts = shows.intCount + shows.FloatCount + shows.AlphanumericCount;
            decimal totalCountss = Convert.ToDecimal(totalCounts);
            per.Floatpercentage = (Convert.ToDecimal(shows.FloatCount) / totalCountss) * 100;
            per.intpercentage = (Convert.ToDecimal(shows.intCount) / totalCountss) * 100;
            per.Alphanumericpercentage = (Convert.ToDecimal(shows.AlphanumericCount) / totalCountss) * 100;

            //Round off
            per.Floatpercentage = Math.Round(per.Floatpercentage, 2);
            per.intpercentage = Math.Round(per.intpercentage, 2);
            per.Alphanumericpercentage = Math.Round(per.Alphanumericpercentage, 2);
            per.Data = AllLine;
            return Ok(per);



        }
     
        [HttpDelete("DeleteFile/", Name = "DeleteFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteFile()
        {

            string fileName = @"C:\Count\Temp.txt";

             if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            return Ok();

        }
       
     }
}
