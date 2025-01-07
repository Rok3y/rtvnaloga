export enum Currency {
    EUR = 0,
    Dollar = 1
  }
  
  export interface AccountHeader {
    id: number;
    number: number;
    dateTime: string;
    currency: Currency;
    recipientName: string;
    recipientAddress: string;
    recipientLocation: string;
  }