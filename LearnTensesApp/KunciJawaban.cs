using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnTensesApp
{
    class KunciJawaban
    {
        /// <summary>
        /// Method untuk mangambil value pada database dan dimasukkan paada sebuah list<string>
        /// </summary>
        /// <returns>list string </returns>
        public List<string> GetKunciJawaban()
        {
            List<string> Kunci = new List<string>();
            using (var db = new ModelKunci_Jawaban())
            {
                var query = from a in db.Kunci_Jawaban select a;
                foreach (var item in query)
                {
                    Kunci.Add(item.Kunci_Jawaban1);
                }
            }
            return Kunci;
        }
    }
}
