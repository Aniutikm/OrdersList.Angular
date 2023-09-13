import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html'
})
export class OrdersListComponent {
  public orders: Order[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Order[]>(baseUrl + 'orders/getorders').subscribe(result => {
      this.orders = result;
    }, error => console.error(error));
  }
}

interface Order {
  id: number;
  customerID: number;
  productID: number;
  totalCost: number;
  status: string;
  customerName: string;
  customerAddress: string;
  statusName: string;
}
