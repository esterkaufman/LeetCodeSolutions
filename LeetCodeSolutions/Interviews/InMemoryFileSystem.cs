using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions.Interviews
{
    public class InMemoryFileSystem
    {
        Dictionary<int, Entity> contentMap = new();
        Directory root = new() { id = -1 };
        public InMemoryFileSystem() { contentMap.Add(-1, root); }
        public void AddFile(int id, string name, string content, string icon, int parentId = -1)
        {
            contentMap.Add(id, new File { id = id, name = name,parentId = parentId ,icon = icon, content = content });
            ((Directory)contentMap[parentId]).childs.Add(contentMap[id]);
        }
        public void AddDir(int id, string name, int parentId = -1)
        {
            contentMap.Add(id, new Directory { id = id, name = name , parentId  = parentId });
            ((Directory)contentMap[parentId]).childs.Add(contentMap[id]);
        }
        public void MoveDir(int id, int newParentId = -1)
        {            
            ((Directory)contentMap[contentMap[id].parentId]).childs.Remove(contentMap[id]);
            ((Directory)contentMap[newParentId]).childs.Add(contentMap[id]);
        }

        public void PrintAll(int id = -1, int level = 0) {
            foreach (var item in ((Directory)contentMap[id]).childs)
            {
                Console.WriteLine(new string(Enumerable.Repeat('\t', level).ToArray()) +item.name);
                if (item is Directory) PrintAll(item.id, level + 1);
            }
        }

        public void Run()
        {
            AddFile(11, "File_1", "", "png");
            AddFile(12, "File_2", "", "png");
            AddDir(13, "Dir_3");
            AddFile(14, "File_4", "", "png");

            AddFile(31, "File3_1", "", "png", 13);
            AddDir(32, "Dir3_2", 13);
            AddFile(33, "File3_3", "", "png", 13);
            AddFile(34, "File3_4", "", "png", 13);

            AddDir(321, "Dir3_2_1", 32);

            AddDir(3211, "Dir3_2_1_1", 321);
            PrintAll();
            //Output
            /*
            File_1
            File_2
            Dir_3
                    File3_1
                    Dir3_2
                            Dir3_2_1
                                    Dir3_2_1_1
                    File3_3
                    File3_4
            File_4
            */
        }
    }
    class Entity
    {
        public int id;
        public int parentId;
        public string name;
        public DateTime createdAt = new();
    }
    class File : Entity
    {
        public string icon;
        public string content;
    }
    class Directory : Entity
    {
        public List<Entity> childs = new();
    }
}
