import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccountHeader } from '../../models/account.model';
import { AccountService } from '../../services/account.service';
import { InvoiceItem } from '../../models/invoiceItem.model';
import { InvoiceService } from '../../services/invoice.service';

@Component({
  selector: 'app-accountDetail',
  templateUrl: './accountDetail.component.html',
  styleUrls: ['./accountDetail.component.css'],
  standalone: false
})

export class AccountDetailComponent implements OnInit {
  account: AccountHeader | null = null;
  invoices: InvoiceItem[] = [];
  totalAmount: number = 0;

  constructor(
    private route: ActivatedRoute,
    private accountService: AccountService,
    private invoiceService: InvoiceService
  ) {}

  ngOnInit(): void {
    // On component init, read the route param (accountId).
    this.route.paramMap.subscribe(params => {
      const idString = params.get('id');
      if (idString) {
        const id = +idString;
        this.loadAccount(id);
        this.loadInvoices(id);
      }
    });
  }

  loadAccount(id: number): void {
    this.accountService.getAccount(id).subscribe({
      next: (data) => {
        this.account = data;
      },
      error: (err) => {
        console.error('Error fetching account details', err);
      }
    });
  }

  loadInvoices(id: number): void {
    // If your Account API returns the invoices directly,
    // you may not need a separate call to invoiceService.
    // But let's assume we do:
    console.log('Loading invoices for account', id);
    this.invoiceService.getInvoicesByAccount(id).subscribe({
      next: (data) => {
        this.invoices = data;
        this.calculateTotal();
        console.log('totalAmount', this.totalAmount);
      },
      error: (err) => {
        //console.error('Error fetching invoices', err);
        console.log("no invoices found");
        this.totalAmount = 0;
        this.invoices = [];
      }
    });
  }

  calculateTotal(): void {
    this.totalAmount = 0;
    for (let i = 0; i < this.invoices.length; i++) {
      this.totalAmount += (this.invoices[i].amount * this.invoices[i].price);
    }
  }

  onDeleteInvoice(invoiceId: number): void {
    console.log('Deleting invoice', invoiceId);
    this.invoiceService.deleteInvoice(invoiceId).subscribe({
      next: () => {
        console.log('Invoice deleted');
        // Remove the deleted invoice from the list
        this.invoices = this.invoices.filter(i => i.id !== invoiceId);
        this.calculateTotal();
      },
      error: (err) => {
        console.error('Error deleting invoice', err);
      }
    });
  }
}
