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
