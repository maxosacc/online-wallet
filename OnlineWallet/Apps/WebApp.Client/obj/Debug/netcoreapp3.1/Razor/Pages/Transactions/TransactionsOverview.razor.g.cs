#pragma checksum "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9139e99f1d5496212dc759582e757e0a916cfe4"
// <auto-generated/>
#pragma warning disable 1591
namespace WebApp.Client.Pages.Transactions
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using WebApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\_Imports.razor"
using WebApp.Client.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/allTransactions")]
    public partial class TransactionsOverview : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>TransactionsOverview</h3>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "container col-md-12");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "row");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(5);
            __builder.AddAttribute(6, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 5 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                          Input

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 5 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                                                 LoginCheck

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "form-group");
                __builder2.AddMarkupContent(11, "<label class=\"col-md-6\" for=\"IdentificationNumber\">Identification number</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(12);
                __builder2.AddAttribute(13, "id", "identificationNumber");
                __builder2.AddAttribute(14, "class", "col-md-4");
                __builder2.AddAttribute(15, "type", "text");
                __builder2.AddAttribute(16, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 8 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                                                                                               Input.IdentificationNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(17, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Input.IdentificationNumber = __value, Input.IdentificationNumber))));
                __builder2.AddAttribute(18, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Input.IdentificationNumber));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(19, "\r\n            ");
                __builder2.OpenElement(20, "div");
                __builder2.AddAttribute(21, "class", "form-group");
                __builder2.AddMarkupContent(22, "<label class=\"col-md-6\" for=\"password\">Bank pin</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(23);
                __builder2.AddAttribute(24, "id", "password");
                __builder2.AddAttribute(25, "class", "col-md-4");
                __builder2.AddAttribute(26, "type", "password");
                __builder2.AddAttribute(27, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 12 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                                                                                       Input.BankPin

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(28, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => Input.BankPin = __value, Input.BankPin))));
                __builder2.AddAttribute(29, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => Input.BankPin));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n            ");
                __builder2.AddMarkupContent(31, "<div class=\"form-group\"><button type=\"submit\" class=\"btn btn-primary ml-2\">Show transactions</button></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n    ");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "row");
#nullable restore
#line 26 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
         if (Transactions.Count <= 0)
        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(35, "<h1>Ucitava se</h1>");
#nullable restore
#line 29 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
        }
        else
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(36, "table");
            __builder.AddAttribute(37, "class", "table table-bordered table-hover");
            __builder.AddMarkupContent(38, @"<thead class=""thead-dark""><tr><th scope=""col"">ID transakcije</th>
                        <th scope=""col"">Sredstva</th>
                        <th scope=""col"">Datum</th>
                        <th scope=""col"">Tip transakcije</th>
                        <th scope=""col"">Tip prenosa</th>
                        <th scope=""col"">Posiljaoc</th>
                        <th scope=""col"">Primalac(ako je transfer tip prenosa)</th></tr></thead>
                ");
            __builder.OpenElement(39, "tbody");
#nullable restore
#line 45 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                     foreach (var item in Transactions)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(40, "tr");
            __builder.OpenElement(41, "td");
            __builder.AddContent(42, 
#nullable restore
#line 48 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                             item.Id.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n                        ");
            __builder.OpenElement(44, "td");
            __builder.AddContent(45, 
#nullable restore
#line 49 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                             item.Amount.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n                        ");
            __builder.OpenElement(47, "td");
            __builder.AddContent(48, 
#nullable restore
#line 50 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                             item.TransactionDateTime.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n                        ");
            __builder.OpenElement(50, "td");
            __builder.AddContent(51, 
#nullable restore
#line 51 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                             item.Type.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n                        ");
            __builder.OpenElement(53, "td");
            __builder.AddContent(54, 
#nullable restore
#line 52 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                             item.TransactionRequestType.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n                        ");
            __builder.OpenElement(56, "td");
            __builder.AddContent(57, 
#nullable restore
#line 53 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                             item.RequestBankAccount.FirstName.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(58, " ");
            __builder.AddContent(59, 
#nullable restore
#line 53 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                                                                           item.RequestBankAccount.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 54 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                         if (item.RecieverBankAccount != null)
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(60, "td");
            __builder.AddContent(61, 
#nullable restore
#line 56 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                                 item.RecieverBankAccount.FirstName.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(62, " ");
            __builder.AddContent(63, 
#nullable restore
#line 56 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                                                                                item.RecieverBankAccount.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 57 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(64, "<td>/</td>");
#nullable restore
#line 61 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 63 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 66 "C:\Users\Maxo\Documents\repos\online-wallet\OnlineWallet\Apps\WebApp.Client\Pages\Transactions\TransactionsOverview.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
