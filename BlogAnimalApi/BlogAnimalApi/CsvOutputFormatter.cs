using BlogAnimalApi.DTO;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAnimalApi
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanWriteType(Type type)
        {
            // Ensure that this formatter only operates on IEnumerable types.
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return typeof(IEnumerable<>).IsAssignableFrom(type);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<AccountDTO> data)
            {
                // Generate the CSV data
                foreach (var item in data)
                {
                    // Customize the data serialization according to your needs.
                    // This is a simple example; you may need to adapt it for your specific data structure.
                    buffer.AppendLine($"{item.AccountId},{item.Username},{item.Email}");
                }

                // Write the CSV data to the response stream
                await response.WriteAsync(buffer.ToString(), selectedEncoding);
            }
        }
    }
}
