import { Component, Input, OnInit } from '@angular/core';
import { Livro } from '../entities/livro';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input()
  livro!: Livro;
  constructor() { }

  ngOnInit(): void {
  }

}
