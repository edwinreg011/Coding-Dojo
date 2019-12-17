from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'secret af'

@app.route('/')
def index():
  if 'your_gold' not in session:
    session['your_gold'] = 0
  return render_template('index.html')

@app.route('/process_money', methods = ['POST'])
def process_money():
  if request.form.get('building') == 'farm':
    gains = random.randint(10,20)
    session['your_gold'] += gains
  if request.form.get('building') == 'cave':
    gains = random.randint(5,10)
    session['your_gold'] += gains
  if request.form.get('building') == 'house':
    gains = random.randint(2,5)
    session['your_gold'] += gains
  if request.form.get('building') == 'casino':
    gains = random.randint(-50,50)
    session['your_gold'] += gains
  return redirect ('/')

@app.route('/reset')
def reset():
  session['your_gold'] = 0
  return redirect ('/')

if __name__ == "__main__":
  app.run(debug=True)