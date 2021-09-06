import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Order } from '../models/order';
import { Orderdetails } from '../models/orderdetails';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  orders: Order[] = [];
  order: Order;
  baseURL: string;
  formData: Order = new Order();
  formDataObj: Orderdetails = new Orderdetails();
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl + 'api/Orders';
  }
  getOrder(): Order[] {
    this.http.get<Order[]>(this.baseURL).subscribe((data: Order[]) => {
      this.orders = data;
    });
    return this.orders;
  }
  getOrderById(id: number) {
    this.http.get(this.baseURL +'/'+ id)
      .toPromise()
      .then(res => this.order = res as Order);
    return this.order;
  }
  postOrder() {
    this.formDataObj.orderID = this.formData.orderID;
    this.formData.orderDetails = this.formDataObj;
    return this.http.post(this.baseURL, this.formData);
  }
  putOrder() {
    this.formDataObj.orderID = this.formData.orderID;
    this.formData.orderDetails = this.formDataObj;
    return this.http.put(`${this.baseURL}/${this.formData.orderID}`, this.formData);
  }
  deleteOrder(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
