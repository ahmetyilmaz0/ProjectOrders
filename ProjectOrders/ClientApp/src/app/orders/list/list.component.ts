import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Order } from '../models/order';
import { OrdersService } from '../service/orders.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  public orders: Order[];
  filter: any = {};
  public baseURL: string;
  constructor(public ordersService: OrdersService, public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Order[]>(baseUrl + 'api/Orders').subscribe(result => {
      this.orders = result;
    }, error => console.error(error));
    this.baseURL = baseUrl + 'api/Orders';
  }

  ngOnInit() {
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.ordersService.deleteOrder(id)
        .subscribe(
          res => {
            this.refreshList();
            //this.toastr.error("Deleted successfully", 'Order Detail');
          },
          err => { console.log(err) }
        )
    }
  }
  refreshList() {
    this.http.get(this.baseURL)
      .toPromise()
      .then(res => this.orders = res as Order[]);
  }
  onChange() {
    var books = this.orders;
    if (this.filter.id) {
      books = books.filter(v => v.orderID == this.filter.id);
    }
    this.orders = books;
  }
  resetFilter() {
    this.filter = {};
    this.onChange();
    this.refreshList();
  }

}
