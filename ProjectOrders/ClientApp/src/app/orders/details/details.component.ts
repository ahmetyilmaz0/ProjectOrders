import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../models/order';
import { OrdersService } from '../service/orders.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  id: number = 0;
  public order: Order;
  baseURL: string;
  constructor(public service: OrdersService,
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string,
    private route: ActivatedRoute,
    private router: Router) {
    this.baseURL = baseUrl + 'api/Orders/';
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['OrderID'];
    this.http.get<Order>(this.baseURL + this.id).subscribe(result => {
      this.order = result;
    }, error => console.error(error));
  }

}
