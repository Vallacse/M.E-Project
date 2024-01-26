import { Component, Input, OnInit } from '@angular/core';
import { Cart, Product } from '../models/models';
import { UtilityService } from '../services/utility.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
  @Input() view: 'grid' | 'list' | 'currcartitem' | 'prevcartitem' = 'grid';
  @Input() product: Product = {
    id: 0,
    title: '',
    description: '',
    price: 0,
    quantity: 0,
    productCategory: {
      id: 1,
      category: '',
      subCategory: '',
    },
    offer: {
      id: 1,
      title: '',
      discount: 0,
    },
    imageName: '',
  };
  @Input() cart: Cart = {
    id: 0,
    ordered: false,
    orderedOn: '',
    user: {
      id: 0,
      firstName: '',
      lastName: '',
      email: '',
      address: '',
      mobile: '',
      password: '',
      createdAt: '',
      modifiedAt: '',
    },
    cartItems:[]
  }

  constructor(public utilityService: UtilityService) { }

  ngOnInit(): void { }
}
