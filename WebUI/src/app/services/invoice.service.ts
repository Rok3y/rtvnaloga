import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InvoiceItem } from '../models/invoiceItem.model';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private baseUrl = 'http://localhost:5081/api/Invoice';

  constructor(private http: HttpClient) {}

  // Example: GET /api/Invoice/accountId/{id}
  getInvoicesByAccount(accountId: number): Observable<InvoiceItem[]> {
    console.log("invoiceAPI", accountId);
    return this.http.get<InvoiceItem[]>(`${this.baseUrl}/accountId?id=${accountId}`);
  }

  deleteInvoice(invoiceId: number): Observable<any> {
    console.log("delete invoice", invoiceId);
    return this.http.delete(`${this.baseUrl}?id=${invoiceId}`);
  }
}