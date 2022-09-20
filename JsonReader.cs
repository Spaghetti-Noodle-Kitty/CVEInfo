using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Automation
{
    internal class JsonReader
    {
        public static void GetCVEInfo(string JSON, bool WANTS_DESCRIPTION)
        {
            string BASE_METRIC_PATH = "$.result.CVE_Items.[0].impact.baseMetricV3.cvssV3."; // Set the base JSON path for most keys //
            var res = (JObject)JsonConvert.DeserializeObject(JSON); // Parse the JSON-String as a JSON-Object //


            // Get all CVE-Info and Save it to CVE_DATA-List //
            List<string> CVE_DATA = new List<string>();

            string PUBLISHED = res.SelectToken("$.result.CVE_Items.[0].publishedDate").ToString().Replace('T',' ').Replace("Z","");        // (YYYY-MM-TT hh:mm) //
            string MODIFIED = res.SelectToken("$.result.CVE_Items.[0].lastModifiedDate").ToString().Replace('T', ' ').Replace("Z", "");    // (YYYY-MM-TT hh:mm) //

            CVE_DATA.Add(res.SelectToken("$.result.CVE_Items.[0].cve.CVE_data_meta.ID") + " Information");                                 // Name of CVE (CVE-Number) //
            CVE_DATA.Add("Base Score:             " + res.SelectToken(BASE_METRIC_PATH + "baseScore"));                                    // Base Score (DOUBLE) //
            CVE_DATA.Add("Base Severity:          " + res.SelectToken(BASE_METRIC_PATH + "baseSeverity"));                                 // base severity (STRING) //
            CVE_DATA.Add("Publishing Date:        " + PUBLISHED);
            CVE_DATA.Add("Last Modified Date:     " + MODIFIED);
            CVE_DATA.Add("-------------------------------------------------------");
            CVE_DATA.Add("Vector:                 " + res.SelectToken(BASE_METRIC_PATH + "attackVector"));                                 // Attack Vector (STRING) //
            CVE_DATA.Add("Complexity:             " + res.SelectToken(BASE_METRIC_PATH + "attackComplexity"));                             // Complexity (STRING) //
            CVE_DATA.Add("Privileges Required:    " + res.SelectToken(BASE_METRIC_PATH + "privilegesRequired"));                           // Privileges (STRING) //
            CVE_DATA.Add("User Interaction:       " + res.SelectToken(BASE_METRIC_PATH + "userInteraction"));                              // User Interaction (STRING) //
            CVE_DATA.Add("Exploitability Score:   " + res.SelectToken("$.result.CVE_Items.[0].impact.baseMetricV3.exploitabilityScore"));  // Exploitability (DOUBLE) //
            CVE_DATA.Add("-------------------------------------------------------");
            CVE_DATA.Add("Confidentiality Impact: " + res.SelectToken(BASE_METRIC_PATH + "confidentialityImpact"));                        // Confidentiality Impact (STRING) //
            CVE_DATA.Add("Integrity Impact:       " + res.SelectToken(BASE_METRIC_PATH + "integrityImpact"));                              // Integrity Impact (STRING) //
            CVE_DATA.Add("Availiability Impact:   " + res.SelectToken(BASE_METRIC_PATH + "availabilityImpact"));                           // Availabilty Impact (STRING) // 
            CVE_DATA.Add("Impact Score:           " + res.SelectToken("$.result.CVE_Items.[0].impact.baseMetricV3.impactScore"));          // Impact Score (DOUBLE) //
            CVE_DATA.Add("-------------------------------------------------------");
            CVE_DATA.Add("https://nvd.nist.gov/vuln/detail/" + res.SelectToken("$.result.CVE_Items.[0].cve.CVE_data_meta.ID"));            // Link to NVD entry for CVE //
            if (WANTS_DESCRIPTION)
            {
                CVE_DATA.Add("-------------------------------------------------------");
                CVE_DATA.Add(res.SelectToken("$.result.CVE_Items.[0].cve.description.description_data.[0].value").ToString());
            }

            foreach (string DATA_STRING in CVE_DATA)
                Console.WriteLine(DATA_STRING); // Print every Line in CVE_DATA-List //
        }
    }
}
