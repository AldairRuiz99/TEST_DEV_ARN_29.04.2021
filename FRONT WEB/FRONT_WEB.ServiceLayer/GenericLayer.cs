using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRONT_WEB.ServiceLayer
{
    public class GenericLayer <T>
    {
        public List<T> Get(string resourceName, T dto)
        {
            List<T> lista = new List<T>();
            String URL = new Uri("https://localhost:44398/api/" + resourceName).ToString();
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);

            request.Method = "GET";
            request.ContentType = "application/json";

            try
            {
                System.Net.WebResponse webResponse = request.GetResponse();
                System.IO.Stream webStream = webResponse.GetResponseStream();
                System.IO.StreamReader responseReader = new System.IO.StreamReader(webStream);
                String response = responseReader.ReadToEnd();

                //ERROR LÓGICO
                lista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(response);
            }
            catch (Exception e)
            {

            }
            return lista;
        }

        public T Get(string resourceName, T dto, int id)
        {
            String URL = new Uri("https://localhost:44398/api/" + resourceName + "/" + id).ToString();
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);

            request.Method = "GET";
            request.ContentType = "application/json";

            try
            {
                System.Net.WebResponse webResponse = request.GetResponse();
                System.IO.Stream webStream = webResponse.GetResponseStream();
                System.IO.StreamReader responseReader = new System.IO.StreamReader(webStream);
                String response = responseReader.ReadToEnd();

                //ERROR LÓGICO
                dto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception e)
            {

            }
            return dto;

        }

        public T Post(string resourceName, T dto)
        {
            //Cabecera de la petición
            string URL = new Uri("https://localhost:44398/api/" + resourceName).ToString();
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";

            //Creación de la petición
            //Añadiendo los datos al body
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            request.ContentLength = data.Length;
            System.IO.StreamWriter requestWriter = new System.IO.StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(data);
            requestWriter.Close();

            try
            {
                //Hacemos la petición HTTP y obtenemos  el stream de respuesta
                System.Net.WebResponse webResponse = request.GetResponse();
                System.IO.Stream webStream = webResponse.GetResponseStream();
                System.IO.StreamReader responseReader = new System.IO.StreamReader(webStream);

                //Leemos la respuesta de inicio a fin  => string
                string response = responseReader.ReadToEnd();

                // Desserializar el objeto que devuelve el API
                dto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
                responseReader.Close();
            }
            catch (Exception e)
            {

            }
            return dto;


        }

        public T Put(string resourceName, T dto)
        {
            //Cabecera de la petición
            String URL = new Uri("https://localhost:44398/api/" + resourceName).ToString();
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
            request.Method = "PUT";
            request.ContentType = "application/json";

            //Creación de la petición
            //Añadiendo los datos al body
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
            request.ContentLength = data.Length;
            System.IO.StreamWriter requestWriter = new System.IO.StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(data);
            requestWriter.Close();

            try
            {
                //Hacemos la petición HTTP y obtenemos  el stream de respuesta
                System.Net.WebResponse webResponse = request.GetResponse();
                System.IO.Stream webStream = webResponse.GetResponseStream();
                System.IO.StreamReader responseReader = new System.IO.StreamReader(webStream);

                //Leemos la respuesta de inicio a fin  => string
                string response = responseReader.ReadToEnd();

                // Desserializar el objeto que devuelve el API
                dto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
                responseReader.Close();
            }
            catch (Exception e)
            {

            }
            return dto;
        }

        public T Delete(string resourceName, T dto, int id)
        {
            //Cabecera de la petición
            string URL = new Uri("https://localhost:44398/api/" + resourceName + "/" + id).ToString();
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
            request.Method = "DELETE";
            request.ContentType = "application/json";

            //Creación de la petición

            try
            {
                //Hacemos la petición HTTP y obtenemos  el stream de respuesta
                System.Net.WebResponse webResponse = request.GetResponse();
                System.IO.Stream webStream = webResponse.GetResponseStream();
                System.IO.StreamReader responseReader = new System.IO.StreamReader(webStream);

                //Leemos la respuesta de inicio a fin  => string
                string response = responseReader.ReadToEnd();
                //Deserializar 
                dto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
                responseReader.Close();
            }
            catch (Exception e)
            {

            }
            return dto;


        }

        #region API TOKA
        public T PostToken(T dto, TESTDTO.UsuarioDTO d)
        {
            //Cabecera de la petición
            string URL = new Uri("https://api.toka.com.mx/candidato/api/login/authenticate").ToString();
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";

            //Creación de la petición
            //Añadiendo los datos al body
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(d);
            request.ContentLength = data.Length;
            System.IO.StreamWriter requestWriter = new System.IO.StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(data);
            requestWriter.Close();

            try
            {
                //Hacemos la petición HTTP y obtenemos  el stream de respuesta
                System.Net.WebResponse webResponse = request.GetResponse();
                System.IO.Stream webStream = webResponse.GetResponseStream();
                System.IO.StreamReader responseReader = new System.IO.StreamReader(webStream);

                //Leemos la respuesta de inicio a fin  => string
                string response = responseReader.ReadToEnd();

                // Desserializar el objeto que devuelve el API
                dto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
                responseReader.Close();
            }
            catch (Exception e)
            {

            }
            return dto;


        }
        public T Get(T dto, string token)
        {
            //List<T> lista = new List<T>();
            String URL = new Uri("https://api.toka.com.mx/candidato/api/customers").ToString();
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);

            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", "Bearer " + token);
            try
            {
                System.Net.WebResponse webResponse = request.GetResponse();
                System.IO.Stream webStream = webResponse.GetResponseStream();
                System.IO.StreamReader responseReader = new System.IO.StreamReader(webStream);
                String response = responseReader.ReadToEnd();

                //ERROR LÓGICO
                dto = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception e)
            {

            }
            return dto;
        }
        #endregion
    }
}
