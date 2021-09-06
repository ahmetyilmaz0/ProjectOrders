import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../models/order';
import { OrdersService } from '../service/orders.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  id: number = 0;
  public order: Order;
  baseURL: string;
  constructor(
    public service: OrdersService,
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.baseURL = baseUrl + 'api/Orders/';
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['OrderID'];
    this.http.get<Order>(this.baseURL + this.id).subscribe(result => {
      this.order = result;
    }, error => console.error(error));
  }
  onSubmit(form: NgForm) {

    this.service.formData.orderID = this.order.orderID;
    this.service.formDataObj.orderDetailID = this.order.orderDetails.orderDetailID;
    this.service.formDataObj.orderID = this.order.orderID;

    if (typeof (this.service.formData.orderName) == 'undefined') {
      this.service.formData.orderName = this.order.orderName;
    }
    if (typeof (this.service.formData.description) == 'undefined') {
      this.service.formData.description = this.order.description;
    }
    if (typeof (this.service.formDataObj.payment) == 'undefined') {
      this.service.formDataObj.payment = this.order.orderDetails.payment;
    }

    this.service.putOrder().subscribe(
      res => {
        this.router.navigateByUrl('orders/list');
      },
      err => {
        console.log(err);
      }
    );
  }
}
