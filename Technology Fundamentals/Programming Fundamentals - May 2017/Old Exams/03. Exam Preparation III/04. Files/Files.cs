//namespace _04.Files
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;

//    public class Files
//    {
//        public static void Main()
//        {
//            var numberOfFilesToRead = int.Parse(Console.ReadLine());

//            //    var file = new List<File>();
//            var dict = new Dictionary<string, Dictionary<string, long>>();
//            // roots - extension - size
//            for (int i = 0; i < numberOfFilesToRead; i++)
//            {
//                //  var input = Console.ReadLine();
//                var fileInput = Console.ReadLine().Split('\\');
//                //var fileNameAndExt = input.Split('\\');
//                var nameAndExtensionArgs = fileInput[fileInput.Length - 1].Split(';');

//                var roots = fileInput[0];
//                //var fileName = string.Concat(nameAndExtensionArgs.Take(1));
//                //  var fileExtension = string.Concat(nameAndExtensionArgs.Skip(1).Take(1));
//                var size = long.Parse(nameAndExtensionArgs[1]);
//                var fileNameExtension = nameAndExtensionArgs[0];

//                if (!dict.ContainsKey(roots))
//                {
//                    dict[roots] = new Dictionary<string, long>();
//                }

//                if (!dict[roots].ContainsKey(fileNameExtension))
//                {
//                    dict[roots].Add(fileNameExtension, size);
//                }

//                else
//                {
//                    dict[roots][fileNameExtension] = size;
//                }
//                //else if(dict[roots].ContainsKey(fileNameExtension))
//                //{
//                //    dict[roots][fileNameExtension] = size;
//                //}
//                //var index = file.
//                //    FindIndex(r => r.Roots.SequenceEqual(roots)
//                //    & r.FileName == fileName
//                //    & r.Extension == fileExtension);

//                //var fileAddInfo = new File(roots, fileName, fileExtension, size);

//                //if (index < 0)
//                //{
//                //    file.Add(fileAddInfo);
//                //}

//                //else
//                //{
//                //    file[index] = fileAddInfo;
//                //}
//            }

//            var resultInput = Console.ReadLine().Split();
//            var extension = resultInput[0];
//            var folder = resultInput[2];

//            //var sorted = file
//            //    .Where(x => x.Extension == extension)
//            //    .Where(x => x.Roots.Substring(0, folder.Length) == folder)
//            //    .OrderByDescending(s => s.FileSize)
//            //    .ThenBy(n => n.FileName);

//            //   var sorted = dict
//            //     .Where(k => k.Key.Substring(0, folder.Length) == folder);
//            //.Where(v => v.Value.Any(x => x.Key.Substring(0, extension.Length) == extension))
//            //.OrderByDescending(s => s.Value.Values)
//            //.ThenBy(v => v.Value);

//            //if (sorted.Count() == 0)
//            //{
//            //    Console.WriteLine("No");
//            //    return;
//            //}

//            if (dict.ContainsKey(folder) && dict[folder].Any(x => x.Key.Substring(x.Key.Length - extension.Length, extension.Length) == extension))
//            {
//                var foundFiles = dict[folder];

//                var sorted = foundFiles
//                    .OrderByDescending(v => v.Value)
//                    .ThenBy(k => k.Key);

//                foreach (var fileInfo in sorted)
//                {
//                    if (fileInfo.Key.EndsWith(extension))
//                    {
//                        Console.WriteLine($"{fileInfo.Key} - {fileInfo.Value} KB");
//                    }
//                }
//            }

//            else
//            {
//                Console.WriteLine("No");
//            }
//        }
//    }
//}

//another solution:
namespace _04.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Files
    {
        public static void Main()
        {
            var numberOfFilesToRead = int.Parse(Console.ReadLine());

            var file = new List<File>();

            for (int i = 0; i < numberOfFilesToRead; i++)
            {
                var fileInput = Console.ReadLine().Split('\\');
                var nameAndExtensionArgs = fileInput[fileInput.Length - 1].Split(';');

                var root = fileInput[0];
                var fileNameAndExt = nameAndExtensionArgs[0];
                var size = long.Parse(nameAndExtensionArgs[1]);

                var index = file.FindIndex(r => r.Root == root & r.FileNameAndExtension == fileNameAndExt);
                var fileAddInfo = new File(root, fileNameAndExt, size);

                if (index < 0)
                {
                    file.Add(fileAddInfo);
                }

                else
                {
                    file[index] = fileAddInfo;
                }
            }

            var resultInput = Console.ReadLine().Split();
            var extension = resultInput[0];
            var folder = resultInput[2];

            var sorted = file
                .Where(r => r.Root == folder)
                .Where(e => e.FileNameAndExtension.EndsWith(extension))
                .OrderByDescending(s => s.FileSize)
                .ThenBy(n => n.FileNameAndExtension);

            if (sorted.Count() == 0)
            {
                Console.WriteLine("No");
                return;
            }

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.FileNameAndExtension} - {item.FileSize} KB");
            }
        }
    }
}