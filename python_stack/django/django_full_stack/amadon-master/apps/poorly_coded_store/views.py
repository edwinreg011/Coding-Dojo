from django.shortcuts import render, redirect, HttpResponse
from .models import Order, Product

def index(request):
    if 'total_quantity' not in request.session:
        request.session['total_quantity'] = 0
    if 'total_price' not in request.session:
        request.session['total_price'] = 0
    context = {
        "all_products": Product.objects.all()
    }
    return render(request, "store/index.html", context)

def buying(request):
    if request.method == 'POST':
        request.session['new_quantity'] = int(request.POST["quantity"])
        request.session['new_price'] = int(request.session['new_quantity']) * float(request.POST['price'])
        request.session['total_quantity'] += int(request.session['new_quantity'])
        request.session[('total_price')] += float(request.session['new_price'])
    return redirect('/checkout')



def checkout(request):
    return render(request, "store/checkout.html")


def reset(request):
    request.session.clear()
    return redirect('/')