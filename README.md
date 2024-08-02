<h1>Postman Requests</h1>

<h2>POST http://localhost:{port}/api/reports/clients  -  To make client id</h2>

<h2>POST http://localhost:{port}/api/reports/clients/{clientId}/instances<br>
  {<br>
    "report": "PatientReport",<br>
    "parameterValues": {<br>
        "p1": "v1",<br>
        "p2": 20<br>
    }<br>
}<br>
  -  To make an instance id</h2>

<h2>POST http://localhost:{port}/api/reports/clients/{clientId}/instances/{instanceId}/documents<br>
  {<br>
    "format": "PDF"<br>
}<br>
  -  To make document id</h2>

<h2>GET http://localhost:{port}/api/reports/clients/{clientId}/instances/{instanceId}/documents/{documentId}  -  To get render report</h2>
