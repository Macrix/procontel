# Replacing WCF with gRPC

Now that you've seen (or just belived in my words), gRPC is used by ProconTEL. However, to tell the truth, v3.0.25.1 was just a starter. In the upcoming weeks we are planing to replace another parts of WCF communication layer with gRPC. If you're interested in checking which version would be most suitable to use in your project, check the table below - it's a schedule for switching ProconTEL features to able to communicate over gRPC.

<table>
  <th>Topic</th>
  <th>Feature</th>
  <th>WCF</th>
  <th>gRPC</th>
<tr>
  <td rowspan="6">Services internal<br>communication</td>
  <td>Channel <-> Pool content exchange</td>
  <td>✓</td>
  <td>v3.0.25.1</td>
</tr>
<tr>
  <td>Channel <-> Pool infrastructure calls</td>
  <td>✓</td>
  <td><i>*</i></td>
</tr>
<tr>
  <td>Channel <-> Administration Service calls</td>
  <td>✓</td>
  <td><i>*</i></td>
</tr>
<tr>
  <td>Pool <-> Administration Service calls</td>
  <td>✓</td>
  <td><i>*</i></td>
</tr>
<tr>
  <td>Service discovery notification about registered pool</td>
  <td>✓</td>
  <td>v3.0.26</td>
</tr>
<tr>
  <td>Content Streaming</td>
  <td>✓</td>
  <td><i>v3.0.27</i></td>
</tr>

<tr>
  <td rowspan="7">Client<br>communication</td>
  <td>Communication Console <-> Administration Service calls</td>
  <td>✓</td>
  <td><i>**</i></td>
</tr>
<tr>
  <td>Endpoint Viewer <-> Administration Service calls</td>
  <td>✓</td>
  <td><i>**</i></td>
</tr>
<tr>
  <td>Endpoint Viewer WPF <-> Administration Service calls</td>
  <td>✓</td>
  <td><i>**</i></td>
</tr>
<tr>
  <td>Log Messages Viewer <-> Administration Service calls</td>
  <td>✓</td>
  <td><i>**</i></td>
</tr>
<tr>
  <td>CLI <-> Administration Service calls</td>
  <td>✓</td>
  <td><i>**</i></td>
</tr>
<tr>
  <td>API <-> Administration Service calls</td>
  <td>✓</td>
  <td><i>**</i></td>
</tr>
<tr>
  <td>File streaming</td>
  <td>✓</td>
  <td><i>**</i></td>
</tr>
</table>

_\*_ - it will be delivered latest by the end of quarter 3 2021<br>
_\**_ - it will be delivered latest by the end of quarter 4 2021


## Next steps

Above table will be updated as soon as we will have a reliable schedule for delivering each feature. Hopefully it will be achived much quicker than end of 2021, so let's stay in touch.