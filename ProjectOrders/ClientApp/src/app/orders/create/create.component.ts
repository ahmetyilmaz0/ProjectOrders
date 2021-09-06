import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Order } from '../models/order';
import { OrdersService } from '../service/orders.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(public service: OrdersService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    this.insertRecord(form);
  }
  insertRecord(form: NgForm) {
    this.service.postOrder().subscribe(
      res => {
        this.resetForm(form);
        this.router.navigateByUrl('orders/list');
      },
      err => {
        console.log(err);
      }
    );
  }
  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Order();
  }
}
