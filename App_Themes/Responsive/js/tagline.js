(function (lib, img, cjs) {

var p; // shortcut to reference prototypes

// library properties:
lib.properties = {
	width: 185,
	height: 45,
	fps: 12,
	color: "#FFFFFF",
	manifest: []
};

// stage content:
(lib.Untitled1 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Layer 2
	this.instance = new lib.Symbol1();
	this.instance.setTransform(169,23.3,0.1,0.1);
	this.instance.alpha = 0;
	this.instance._off = true;

	this.timeline.addTween(cjs.Tween.get(this.instance).wait(19).to({_off:false},0).to({scaleX:1.05,scaleY:1.05,y:20.8,alpha:1},6,cjs.Ease.get(-1)).to({scaleX:1,scaleY:1},2).wait(73));

	// Layer 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#808080").s().p("AglA/IAAh+IARAAIAABxIA6AAIAAANg");
	this.shape.setTransform(7.5,31.7);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#808080").s().p("AAQAzQgMgNAAgVIAAgEQAAgSANgOQAMgNAQAAQATgBAKAMQAKAMAAARIAAALIg+AAIAAABQAAANAHAJQAHAIAMAAQAJAAAGgBQAHgDAFgEIAGAKQgFAFgIAEQgIAEgMAAQgUAAgMgOgAAegLQgGAHgBAJIAAAAIAsAAIAAgCQAAgIgGgHQgFgGgLgBQgJAAgGAIgAhTA+IAAh+IARAAIAABxIA8AAIAAANg");
	this.shape_1.setTransform(12.1,31.8);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f("#808080").s().p("AA8A5QgHgIgBgNQABgOAKgIQALgHAUAAIASAAIAAgIQAAgIgFgFQgFgEgJgBQgJAAgFAFQgFAEAAAGIgRAAIAAgBQgBgKALgIQAKgJARAAQAQgBAKAJQAJAIABAPIAAAsIAAAKIACAJIgSAAIgBgHIgBgGQgFAGgIAFQgHAFgKAAQgOAAgIgIgABMAYQgGAFAAAHQAAAGADAEQAFAEAIAAQAIAAAIgFQAIgFACgGIAAgQIgTAAQgLABgGAFgAgdAzQgNgNAAgVIAAgEQAAgSANgOQAMgNAQAAQARgBAKAMQAKAMAAARIAAALIg8AAIAAABQABANAGAJQAHAIAKAAQAJAAAGgBQAHgDAFgEIAGAKQgEAFgJAEQgIAEgMAAQgSAAgLgOgAgQgLQgFAHgCAJIAAAAIAqAAIAAgCQAAgIgFgHQgGgGgJgBQgJAAgGAIgAiDA+IAAh+IARAAIAABxIA8AAIAAANg");
	this.shape_2.setTransform(16.9,31.8);

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.f("#808080").s().p("AAZA5QgHgIgBgNQABgOAKgIQALgHAUAAIASAAIAAgIQAAgIgFgFQgFgEgJgBQgJAAgFAFQgFAEAAAGIgRAAIAAgBQgBgKALgIQAKgJARAAQAQgBAKAJQAJAIABAPIAAAsIAAAKIACAJIgSAAIgBgHIgBgGQgFAGgIAFQgHAFgKAAQgOAAgIgIgAApAYQgGAFAAAHQAAAGADAEQAFAEAIAAQAIAAAIgFQAIgFACgGIAAgQIgTAAQgLABgGAFgAhAAzQgNgNAAgVIAAgEQAAgSANgOQAMgNAQAAQATgBAKAMQAIAMAAARIAAALIg8AAIAAABQABANAGAJQAHAIAMAAQAJAAAGgBQAHgDAFgEIAGAKQgEAFgJAEQgIAEgMAAQgUAAgLgOgAgzgLQgFAHgCAJIAAAAIAsAAIAAgCQAAgIgFgHQgGgGgLgBQgJAAgGAIgAB3A+IAAhcIAQAAIABANQAFgHAFgEQAGgFAJABIADAAIADABIgDAPIgJAAQgGAAgFAEQgFACgCAHIAABBgAimA+IAAh+IARAAIAABxIA8AAIAAANg");
	this.shape_3.setTransform(20.4,31.8);

	this.shape_4 = new cjs.Shape();
	this.shape_4.graphics.f("#808080").s().p("AgTA5QgHgIAAgNQAAgOALgIQALgHARAAIASAAIAAgIQAAgIgEgFQgGgEgJgBQgJAAgDAFQgFAEAAAGIgRAAIAAgBQAAgKAKgIQAKgJAPAAQAQgBAKAJQAKAIAAAPIAAAsIAAAKIACAJIgSAAIgBgHIgBgGQgEAGgIAFQgIAFgJAAQgNAAgIgIgAgDAYQgGAFAAAHQAAAGAEAEQAEAEAGAAQAJAAAHgFQAJgFABgGIAAgQIgTAAQgKABgFAFgAhuAzQgMgNAAgVIAAgEQAAgSAMgOQANgNAQAAQATgBAKAMQAKAMAAARIAAALIg+AAIAAABQAAANAHAJQAHAIAMAAQAIAAAHgBQAGgDAGgEIAGAKQgFAFgJAEQgIAEgLAAQgVAAgLgOgAhggLQgGAHgCAJIAAAAIAtAAIAAgCQgBgIgFgHQgGgGgKgBQgJAAgGAIgADDA+IAAg7QAAgKgEgGQgFgFgLgBQgHAAgGAFQgGADgDAGIAABDIgRAAIAAhcIAPAAIACANQAEgHAHgEQAHgFAKABQAPAAAIAJQAIAIAAASIAAA7gABKA+IAAhcIAQAAIABANQAFgHAFgEQAGgFAIABIAEAAIACABIgCAPIgJAAQgGAAgFAEQgFACgCAHIAABBgAjUA+IAAh+IASAAIAABxIA8AAIAAANg");
	this.shape_4.setTransform(24.9,31.8);

	this.shape_5 = new cjs.Shape();
	this.shape_5.graphics.f("#808080").s().p("AgpA9QgHgHAAgNQAAgOALgIQALgIATABIAQAAIAAgKQAAgHgEgFQgFgEgIAAQgJAAgEAEQgGAFAAAFIgRAAIAAgBQAAgKAKgIQAKgJARAAQAOAAAKAJQAKAIAAANIAAAuIAAAKIACAJIgSAAIgBgIIgBgGQgEAGgGAGQgIAEgJAAQgPAAgIgIgAgZAcQgGAFAAAIQAAAGAEAEQAEADAIAAQAJAAAGgEQAIgFABgGIAAgQIgRAAQgKAAgHAFgAiEA4QgMgOAAgUIAAgFQAAgSAMgNQANgOAQAAQATAAAKALQAKAMAAASIAAALIg+AAIAAAAQAAAOAHAJQAHAIAMAAQAIAAAHgCQAGgDAGgEIAGALQgFAFgJAEQgIADgLAAQgVAAgLgNgAh2gHQgGAHgCAJIAAABIAtAAIAAgDQgBgIgFgHQgGgGgKAAQgJAAgGAHgADZBDIAAhdIARAAIAABdgACtBDIAAg8QAAgKgEgGQgFgFgLAAQgHAAgGAEQgGAEgDAFIAABEIgRAAIAAhdIAPAAIACAOQAEgHAHgEQAHgFAKAAQAPAAAIAJQAIAJAAARIAAA8gAA0BDIAAhdIAQAAIABAOQAFgHAFgEQAGgFAIAAIAEAAIACABIgCAQIgJAAQgGAAgFADQgFADgCAFIAABDgAjqBDIAAh+IASAAIAABwIA8AAIAAAOgADZgyIAAgSIARAAIAAASg");
	this.shape_5.setTransform(27.1,31.4);

	this.shape_6 = new cjs.Shape();
	this.shape_6.graphics.f("#808080").s().p("AhcA9QgIgHAAgNQAAgOALgIQALgIATABIATAAIAAgKQAAgHgFgFQgFgEgKAAQgIAAgFAEQgFAFAAAFIgRAAIAAgBQgBgKALgIQAKgJAQAAQAQAAAKAJQAKAIAAANIAAAuIABAKIACAJIgSAAIgCgIIAAgGQgFAGgIAGQgIAEgJAAQgOAAgIgIgAhMAcQgHAFAAAIQAAAGAEAEQAEADAIAAQAJAAAIgEQAIgFACgGIAAgQIgUAAQgKAAgGAFgAi4A4QgMgOAAgUIAAgFQAAgSANgNQAMgOAQAAQATAAAKALQAKAMAAASIAAALIg+AAIAAAAQAAAOAHAJQAHAIAMAAQAJAAAGgCQAHgDAFgEIAGALQgFAFgIAEQgIADgMAAQgUAAgMgNgAiqgHQgGAHgBAJIAAABIAsAAIAAgDQAAgIgGgHQgFgGgLAAQgJAAgGAHgAENBDIAAg8QAAgKgFgGQgFgFgKAAQgHAAgGAEQgGAEgDAFIAABEIgSAAIAAhdIAQAAIABAOQAFgHAHgEQAHgFAJAAQAQAAAIAJQAIAJAAARIAAA8gAClBDIAAhdIASAAIAABdgAB6BDIAAg8QAAgKgFgGQgFgFgKAAQgIAAgGAEQgFAEgEAFIAABEIgRAAIAAhdIAPAAIACAOQAEgHAHgEQAIgFAJAAQAPAAAJAJQAIAJAAARIAAA8gAAABDIAAhdIAQAAIABAOQAFgHAFgEQAGgFAIAAIAEAAIADABIgDAQIgJAAQgGAAgFADQgFADgCAFIAABDgAkdBDIAAh+IARAAIAABwIA8AAIAAAOgAClgyIAAgSIASAAIAAASg");
	this.shape_6.setTransform(32.3,31.4);

	this.shape_7 = new cjs.Shape();
	this.shape_7.graphics.f("#808080").s().p("AEZBVQgIgCgGgDIAFgNQAEACAHACQAHACAGAAQANAAAFgGQAGgGAAgMIAAgKQgEAGgHADQgGADgJAAQgRAAgKgNQgKgNAAgUIAAgCQAAgVAKgOQAKgOARAAQAJAAAHAEQAHADAFAHIACgMIANAAIAABdQAAATgKAJQgLAKgUAAQgHAAgIgCgAEYgWQgGALAAAOIAAACQAAAOAGAJQAGAJAMAAQAIAAAFgEQAGgEADgGIAAgqQgDgGgGgDQgFgEgHAAQgNAAgGAKgAiPArQgIgIAAgNQAAgOALgHQALgGATAAIATAAIAAgJQAAgJgFgFQgFgEgKAAQgIAAgFAEQgFAEAAAGIgRAAIAAgBQgBgKALgIQAKgJAQAAQAQAAAKAIQAKAIAAAQIAAAsIABAJIACAKIgSAAIgCgIIAAgGQgFAGgIAFQgIAFgJAAQgOAAgIgIgAh/AKQgHAFAAAHQAAAHAEADQAEAEAIAAQAJAAAIgFQAIgFACgGIAAgPIgUAAQgKAAgGAFgAjrAlQgMgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQAAANAHAJQAHAJAMAAQAJAAAGgCQAHgDAFgEIAGALQgFAFgIADQgIAEgMAAQgUAAgMgOgAjdgZQgGAHgBALIAAABIAsAAIAAgDQAAgKgGgHQgFgGgLAAQgJAAgGAHgADaAxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgGAEQgGADgDAGIAABEIgSAAIAAhdIAQAAIABAOQAFgIAHgEQAHgEAJAAQAQAAAIAJQAIAJAAATIAAA6gAByAxIAAhdIASAAIAABdgABHAxIAAg6QAAgMgFgGQgFgFgKAAQgIAAgGAEQgFADgEAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAIgEAJAAQAPAAAJAJQAIAJAAATIAAA6gAgxAxIAAhdIAQAAIABAOQAFgIAFgEQAGgEAIAAIAEAAIADABIgDAQIgJgBQgGAAgFAEQgFADgCAGIAABCgAlQAxIAAh+IARAAIAABwIA8AAIAAAOgAByhFIAAgRIASAAIAAARg");
	this.shape_7.setTransform(37.4,33.2);

	this.shape_8 = new cjs.Shape();
	this.shape_8.graphics.f("#808080").s().p("ADtBVQgIgCgGgDIAFgNQAEACAGACQAIACAGAAQANAAAFgGQAGgGAAgMIAAgKQgFAGgGADQgHADgIAAQgSAAgKgNQgKgNAAgUIAAgCQAAgVAKgOQAKgOASAAQAJAAAHAEQAHADAEAHIADgMIANAAIAABdQAAATgKAJQgLAKgUAAQgHAAgIgCgADsgWQgGALgBAOIAAACQAAAOAHAJQAFAJANAAQAIAAAFgEQAFgEAEgGIAAgqQgEgGgFgDQgFgEgHAAQgNAAgGAKgAi8ArQgHgIAAgNQAAgOALgHQALgGATAAIASAAIAAgJQAAgJgEgFQgGgEgJAAQgJAAgEAEQgGAEAAAGIgRAAIAAgBQAAgKAKgIQAKgJARAAQAQAAAKAIQAKAIAAAQIAAAsIAAAJIACAKIgSAAIgBgIIgBgGQgEAGgIAFQgIAFgJAAQgPAAgIgIgAisAKQgGAFAAAHQAAAHAEADQAEAEAIAAQAJAAAHgFQAJgFABgGIAAgPIgTAAQgKAAgHAFgAkXAlQgMgNAAgVIAAgDQAAgTAMgOQANgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQAAANAHAJQAHAJAMAAQAIAAAHgCQAGgDAGgEIAGALQgFAFgJADQgIAEgLAAQgVAAgLgOgAkJgZQgGAHgCALIAAABIAtAAIAAgDQgBgKgFgHQgGgGgKAAQgJAAgGAHgAFsAxIAAhdIASAAIAABdgACuAxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgHAEQgFADgEAGIAABEIgRAAIAAhdIAQAAIABAOQAFgIAGgEQAIgEAJAAQAQAAAIAJQAIAJAAATIAAA6gABGAxIAAhdIARAAIAABdgAAaAxIAAg6QAAgMgEgGQgFgFgLAAQgGAAgFAEQgGADgDAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAFgEAKAAQAPAAAIAJQAIAJAAATIAAA6gAhdAxIAAhdIAQAAIABAOQAFgIAFgEQAGgEAIAAIAEAAIACABIgCAQIgJgBQgGAAgFAEQgFADgCAGIAABCgAl9AxIAAh+IASAAIAABwIA8AAIAAAOgAFshFIAAgRIASAAIAAARgABGhFIAAgRIARAAIAAARg");
	this.shape_8.setTransform(41.8,33.2);

	this.shape_9 = new cjs.Shape();
	this.shape_9.graphics.f("#808080").s().p("AC5BVQgIgCgGgDIAFgNQAEACAHACQAHACAGAAQANAAAFgGQAGgGAAgMIAAgKQgEAGgHADQgGADgJAAQgRAAgKgNQgKgNAAgUIAAgCQAAgVAKgOQAKgOARAAQAJAAAHAEQAHADAFAHIACgMIANAAIAABdQAAATgKAJQgLAKgUAAQgHAAgIgCgAC4gWQgGALAAAOIAAACQAAAOAGAJQAGAJAMAAQAIAAAFgEQAGgEADgGIAAgqQgDgGgGgDQgFgEgHAAQgNAAgGAKgAjvArQgIgIAAgNQAAgOALgHQALgGATAAIATAAIAAgJQAAgJgFgFQgFgEgKAAQgIAAgFAEQgFAEAAAGIgRAAIAAgBQgBgKALgIQAKgJAQAAQAQAAAKAIQAKAIAAAQIAAAsIABAJIACAKIgSAAIgCgIIAAgGQgFAGgIAFQgIAFgJAAQgOAAgIgIgAjfAKQgHAFAAAHQAAAHAEADQAEAEAIAAQAJAAAIgFQAIgFACgGIAAgPIgUAAQgKAAgGAFgAlLAlQgMgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQAAANAHAJQAHAJAMAAQAJAAAGgCQAHgDAFgEIAGALQgFAFgIADQgIAEgMAAQgUAAgMgOgAk9gZQgGAHgBALIAAABIAsAAIAAgDQAAgKgGgHQgFgGgLAAQgJAAgGAHgAGgAxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgGAEQgGADgDAGIAABEIgSAAIAAhdIAQAAIABAOQAFgIAHgEQAHgEAJAAQAQAAAIAJQAIAJAAATIAAA6gAE4AxIAAhdIASAAIAABdgAB6AxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgGAEQgGADgDAGIAABEIgSAAIAAhdIAQAAIABAOQAFgIAHgEQAHgEAJAAQAQAAAIAJQAIAJAAATIAAA6gAASAxIAAhdIASAAIAABdgAgXAxIAAg6QAAgMgFgGQgFgFgKAAQgIAAgGAEQgFADgEAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAIgEAJAAQAPAAAJAJQAIAJAAATIAAA6gAiRAxIAAhdIAQAAIABAOQAFgIAFgEQAGgEAIAAIAEAAIADABIgDAQIgJgBQgGAAgFAEQgFADgCAGIAABCgAmwAxIAAh+IARAAIAABwIA8AAIAAAOgAE4hFIAAgRIASAAIAAARgAAShFIAAgRIASAAIAAARg");
	this.shape_9.setTransform(47,33.2);

	this.shape_10 = new cjs.Shape();
	this.shape_10.graphics.f("#808080").s().p("ACBBVQgHgCgGgDIAEgNQAFACAGACQAHACAGAAQANAAAFgGQAGgGABgMIAAgKQgFAGgHADQgGADgIAAQgSAAgKgNQgKgNAAgUIAAgCQAAgVAKgOQAKgOASAAQAIAAAIAEQAGADAFAHIACgMIAOAAIAABdQAAATgLAJQgLAKgUAAQgHAAgIgCgACAgWQgGALAAAOIAAACQAAAOAGAJQAGAJAMAAQAIAAAGgEQAFgEAEgGIAAgqQgEgGgFgDQgGgEgHAAQgMAAgHAKgAHLAsQgGgGgBgOIAAg4IgOAAIAAgMIAOAAIAAgXIASAAIAAAXIASAAIAAAMIgSAAIAAA4QAAAHACADQADACAFAAIAEAAIADgBIACAMQgCACgEABIgHABQgLAAgGgHgAknArQgHgIgBgNQABgOAKgHQALgGAUAAIASAAIAAgJQAAgJgFgFQgFgEgJAAQgJAAgFAEQgFAEAAAGIgRAAIAAgBQgBgKALgIQAKgJARAAQAQAAAKAIQAJAIABAQIAAAsIAAAJIACAKIgSAAIgBgIIgBgGQgFAGgIAFQgHAFgKAAQgOAAgIgIgAkXAKQgGAFAAAHQAAAHADADQAFAEAIAAQAIAAAIgFQAIgFACgGIAAgPIgTAAQgLAAgGAFgAmCAlQgNgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQABANAGAJQAHAJAMAAQAJAAAGgCQAHgDAFgEIAGALQgEAFgJADQgIAEgMAAQgUAAgLgOgAl1gZQgFAHgCALIAAABIAsAAIAAgDQAAgKgFgHQgGgGgLAAQgJAAgGAHgAFpAxIAAg6QAAgMgGgGQgEgFgKAAQgIAAgGAEQgGADgDAGIAABEIgSAAIAAhdIAQAAIABAOQAFgIAHgEQAIgEAIAAQAQAAAIAJQAJAJAAATIAAA6gAEAAxIAAhdIASAAIAABdgABCAxIAAg6QAAgMgEgGQgGgFgKAAQgHAAgGAEQgGADgDAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAIgEAJAAQAPAAAIAJQAJAJgBATIAAA6gAgjAxIAAhdIARAAIAABdgAhPAxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgHAEQgFADgEAGIAABEIgRAAIAAhdIAPAAIACAOQAFgIAGgEQAIgEAJAAQAQAAAIAJQAIAJAAATIAAA6gAjJAxIAAhdIAQAAIABAOQAFgIAFgEQAGgEAJAAIADAAIADABIgDAQIgJgBQgGAAgFAEQgFADgCAGIAABCgAnoAxIAAh+IARAAIAABwIA8AAIAAAOgAEAhFIAAgRIASAAIAAARgAgjhFIAAgRIARAAIAAARg");
	this.shape_10.setTransform(52.6,33.2);

	this.shape_11 = new cjs.Shape();
	this.shape_11.graphics.f("#808080").s().p("ABRBVQgIgCgGgDIAEgNQAFACAGACQAHACAHAAQAMAAAGgGQAGgGAAgMIAAgKQgFAGgGADQgHADgIAAQgSAAgKgNQgKgNAAgUIAAgCQAAgVAKgOQAKgOASAAQAJAAAHAEQAHADAEAHIACgMIAOAAIAABdQAAATgLAJQgKAKgUAAQgHAAgIgCgABQgWQgHALAAAOIAAACQAAAOAGAJQAGAJANAAQAIAAAFgEQAFgEAEgGIAAgqQgEgGgFgDQgFgEgIAAQgMAAgGAKgAGaAsQgGgGAAgOIAAg4IgPAAIAAgMIAPAAIAAgXIARAAIAAAXIASAAIAAAMIgSAAIAAA4QAAAHADADQADACAEAAIAEAAIADgBIACAMQgCACgEABIgHABQgLAAgGgHgAlYArQgHgIAAgNQAAgOALgHQALgGATAAIASAAIAAgJQAAgJgFgFQgFgEgJAAQgJAAgFAEQgFAEAAAGIgRAAIAAgBQAAgKAKgIQAKgJARAAQAQAAAKAIQAKAIAAAQIAAAsIAAAJIACAKIgSAAIgBgIIgBgGQgFAGgHAFQgIAFgJAAQgPAAgIgIgAlIAKQgGAFAAAHQAAAHAEADQAEAEAIAAQAJAAAHgFQAIgFACgGIAAgPIgTAAQgLAAgGAFgAmzAlQgMgNAAgVIAAgDQAAgTAMgOQAMgNARAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQAAANAHAJQAGAJAMAAQAJAAAHgCQAGgDAFgEIAHALQgFAFgJADQgIAEgMAAQgUAAgLgOgAmlgZQgGAHgCALIAAABIAsAAIAAgDQAAgKgFgHQgGgGgKAAQgJAAgGAHgAIIAxIAAg6QAAgMgFgFQgFgGgKAAQgHAAgGADQgGAEgDAGIAABEIgSAAIAAiHIASAAIAAA2QAFgGAHgEQAHgEAJAAQAPAAAIAJQAJAJAAATIAAA6gAE4AxIAAg6QAAgMgFgGQgFgFgKAAQgIAAgGAEQgFADgEAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAIgEAJAAQAPAAAJAJQAIAJAAATIAAA6gADQAxIAAhdIARAAIAABdgAASAxIAAg6QAAgMgFgGQgFgFgIAAQgIAAgGAEQgFADgEAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAIgEAHAAQAPAAAJAJQAIAJAAATIAAA6gAhUAxIAAhdIARAAIAABdgAiAAxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgGAEQgGADgDAGIAABEIgSAAIAAhdIAQAAIABAOQAFgIAHgEQAHgEAJAAQAQAAAIAJQAIAJAAATIAAA6gAj5AxIAAhdIAPAAIACAOQAEgIAGgEQAGgEAIAAIADAAIADABIgCAQIgJgBQgHAAgFAEQgEADgDAGIAABCgAoZAxIAAh+IARAAIAABwIA9AAIAAAOgADQhFIAAgRIARAAIAAARgAhUhFIAAgRIARAAIAAARg");
	this.shape_11.setTransform(57.4,33.2);

	this.shape_12 = new cjs.Shape();
	this.shape_12.graphics.f("#808080").s().p("AAeBVQgHgCgGgDIAEgNQAFACAGACQAHACAGAAQANAAAFgGQAGgGABgMIAAgKQgFAGgHADQgGADgIAAQgSAAgKgNQgKgNAAgUIAAgCQAAgVAKgOQAKgOASAAQAIAAAIAEQAGADAFAHIACgMIAOAAIAABdQAAATgLAJQgLAKgUAAQgHAAgIgCgAAdgWQgGALAAAOIAAACQAAAOAGAJQAGAJAMAAQAIAAAGgEQAFgEAEgGIAAgqQgEgGgFgDQgGgEgHAAQgMAAgHAKgAIIAlQgMgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQAAANAHAJQAGAJAMAAQAKAAAGgCQAHgDAEgEIAHALQgFAFgJADQgHAEgNAAQgTAAgMgOgAIWgZQgGAHgCALIAAABIAsAAIAAgDQABgKgGgHQgFgGgLAAQgJAAgGAHgAFoAsQgGgGgBgOIAAg4IgOAAIAAgMIAOAAIAAgXIASAAIAAAXIASAAIAAAMIgSAAIAAA4QAAAHACADQADACAFAAIAEAAIADgBIACAMQgCACgEABIgHABQgLAAgGgHgAmKArQgHgIgBgNQABgOAKgHQALgGAUAAIASAAIAAgJQAAgJgFgFQgFgEgJAAQgJAAgFAEQgFAEAAAGIgRAAIAAgBQgBgKALgIQAKgJARAAQAQAAAKAIQAJAIABAQIAAAsIAAAJIACAKIgSAAIgBgIIgBgGQgFAGgIAFQgHAFgKAAQgOAAgIgIgAl6AKQgGAFAAAHQAAAHADADQAFAEAIAAQAIAAAIgFQAIgFACgGIAAgPIgTAAQgLAAgGAFgAnlAlQgNgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQABANAGAJQAHAJAMAAQAJAAAGgCQAHgDAFgEIAHALQgFAFgJADQgIAEgMAAQgUAAgLgOgAnYgZQgFAHgCALIAAABIAsAAIAAgDQAAgKgFgHQgGgGgLAAQgJAAgGAHgAHWAxIAAg6QAAgMgFgFQgFgGgKAAQgHAAgGADQgGAEgEAGIAABEIgRAAIAAiHIARAAIAAA2QAGgGAHgEQAGgEAKAAQAPAAAIAJQAIAJAAATIAAA6gAEGAxIAAg6QAAgMgGgGQgEgFgKAAQgIAAgGAEQgGADgDAGIAABEIgSAAIAAhdIAQAAIABAOQAFgIAHgEQAIgEAIAAQAQAAAIAJQAJAJAAATIAAA6gACdAxIAAhdIASAAIAABdgAgfAxIAAg6QAAgMgEgGQgGgFgKAAQgHAAgGAEQgGADgDAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAIgEAJAAQAPAAAIAJQAJAJgBATIAAA6gAiGAxIAAhdIARAAIAABdgAiyAxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgHAEQgFADgEAGIAABEIgRAAIAAhdIAPAAIACAOQAFgIAGgEQAIgEAJAAQAQAAAIAJQAIAJAAATIAAA6gAksAxIAAhdIAQAAIABAOQAFgIAFgEQAGgEAJAAIADAAIADABIgDAQIgJgBQgGAAgFAEQgFADgCAGIAABCgApLAxIAAh+IARAAIAABwIA8AAIAAAOgACdhFIAAgRIASAAIAAARgAiGhFIAAgRIARAAIAAARg");
	this.shape_12.setTransform(62.5,33.2);

	this.shape_13 = new cjs.Shape();
	this.shape_13.graphics.f("#808080").s().p("AgmBVQgHgCgGgDIAEgNQAFACAGACQAHACAGAAQANAAAFgGQAFgGAAgMIAAgKQgDAGgHADQgGADgIAAQgSAAgKgNQgKgNAAgUIAAgCQAAgVAKgOQAKgOASAAQAIAAAIAEQAGADADAHIACgMIAOAAIAABdQAAATgLAJQgJAKgUAAQgHAAgIgCgAgngWQgGALAAAOIAAACQAAAOAGAJQAGAJAMAAQAIAAAGgEQAFgEACgGIAAgqQgCgGgFgDQgGgEgHAAQgMAAgHAKgAJMAlQgLgNABgVIAAgDQgBgTALgNQAMgOAUAAQARAAALAKQAKAKAAAOIAAAAIgQAAQAAgIgGgGQgHgGgJAAQgOAAgFAJQgGAKAAANIAAADQAAAPAFAJQAHAKANAAQAJAAAGgFQAHgGAAgHIAQAAIAAAAQAAAMgLAKQgMAKgPAAQgUAAgMgOgAHCAlQgMgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQAAANAHAJQAGAJAMAAQAKAAAGgCQAHgDAEgEIAHALQgFAFgJADQgHAEgNAAQgTAAgMgOgAHQgZQgGAHgCALIAAABIAsAAIAAgDQABgKgGgHQgFgGgLAAQgJAAgGAHgAEiAsQgGgGgBgOIAAg4IgOAAIAAgMIAOAAIAAgXIASAAIAAAXIASAAIAAAMIgSAAIAAA4QAAAHACADQADACAFAAIAEAAIADgBIACAMQgCACgEABIgHABQgLAAgGgHgAnQArQgHgIgBgNQABgOAKgHQALgGAUAAIASAAIAAgJQAAgJgFgFQgFgEgJAAQgJAAgFAEQgFAEAAAGIgRAAIAAgBQgBgKALgIQAKgJARAAQAQAAAKAIQAJAIABAQIAAAsIAAAJIACAKIgSAAIgBgIIgBgGQgFAGgIAFQgHAFgKAAQgOAAgIgIgAnAAKQgGAFAAAHQAAAHADADQAFAEAIAAQAIAAAIgFQAIgFACgGIAAgPIgTAAQgLAAgGAFgAorAlQgNgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQABANAGAJQAHAJAMAAQAJAAAGgCQAHgDAFgEIAGALQgEAFgJADQgIAEgMAAQgUAAgLgOgAoegZQgFAHgCALIAAABIAsAAIAAgDQAAgKgFgHQgGgGgLAAQgJAAgGAHgAGQAxIAAg6QAAgMgFgFQgFgGgKAAQgHAAgGADQgGAEgEAGIAABEIgRAAIAAiHIARAAIAAA2QAGgGAHgEQAGgEAKAAQAPAAAIAJQAIAJAAATIAAA6gADAAxIAAg6QAAgMgGgGQgEgFgKAAQgIAAgGAEQgGADgDAGIAABEIgSAAIAAhdIAQAAIABAOQAFgIAHgEQAIgEAIAAQAQAAAIAJQAJAJAAATIAAA6gABXAxIAAhdIASAAIAABdgAhlAxIAAg6QAAgMgEgGQgGgFgKAAQgHAAgGAEQgGADgDAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAIgEAJAAQAPAAAIAJQAJAJgBATIAAA6gAjMAxIAAhdIARAAIAABdgAj4AxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgHAEQgFADgEAGIAABEIgRAAIAAhdIAPAAIACAOQAFgIAGgEQAIgEAJAAQAQAAAIAJQAIAJAAATIAAA6gAlyAxIAAhdIAQAAIABAOQAFgIAFgEQAGgEAJAAIADAAIADABIgDAQIgJgBQgGAAgFAEQgFADgCAGIAABCgAqRAxIAAh+IARAAIAABwIA8AAIAAAOgABXhFIAAgRIASAAIAAARgAjMhFIAAgRIARAAIAAARg");
	this.shape_13.setTransform(69.5,33.2);

	this.shape_14 = new cjs.Shape();
	this.shape_14.graphics.f("#808080").s().p("Ag5BVQgHgCgGgDIAEgNQAFACAGACQAHACAGAAQANAAAFgGQAGgGABgMIAAgKQgFAGgHADQgGADgIAAQgSAAgKgNQgKgNAAgUIAAgCQAAgVAKgOQAKgOASAAQAIAAAIAEQAGADAFAHIACgMIAOAAIAABdQAAATgLAJQgLAKgUAAQgHAAgIgCgAg6gWQgGALAAAOIAAACQAAAOAGAJQAGAJAMAAQAIAAAGgEQAFgEAEgGIAAgqQgEgGgFgDQgGgEgHAAQgMAAgHAKgAI5AlQgLgNABgVIAAgDQgBgTALgNQAMgOAUAAQARAAALAKQAKAKAAAOIAAAAIgQAAQAAgIgGgGQgHgGgJAAQgOAAgFAJQgGAKAAANIAAADQAAAPAFAJQAHAKANAAQAJAAAGgFQAHgGAAgHIAQAAIAAAAQAAAMgLAKQgMAKgPAAQgUAAgMgOgAGvAlQgMgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQAAANAHAJQAGAJAMAAQAKAAAGgCQAHgDAEgEIAHALQgFAFgJADQgHAEgNAAQgTAAgMgOgAG9gZQgGAHgCALIAAABIAsAAIAAgDQABgKgGgHQgFgGgLAAQgJAAgGAHgAEPAsQgGgGgBgOIAAg4IgOAAIAAgMIAOAAIAAgXIASAAIAAAXIASAAIAAAMIgSAAIAAA4QAAAHACADQADACAFAAIAEAAIADgBIACAMQgCACgEABIgHABQgLAAgGgHgAnjArQgHgIgBgNQABgOAKgHQALgGAUAAIASAAIAAgJQAAgJgFgFQgFgEgJAAQgJAAgFAEQgFAEAAAGIgRAAIAAgBQgBgKALgIQAKgJARAAQAQAAAKAIQAJAIABAQIAAAsIAAAJIACAKIgSAAIgBgIIgBgGQgFAGgIAFQgHAFgKAAQgOAAgIgIgAnTAKQgGAFAAAHQAAAHADADQAFAEAIAAQAIAAAIgFQAIgFACgGIAAgPIgTAAQgLAAgGAFgAo+AlQgNgNAAgVIAAgDQAAgTANgOQAMgNAQAAQATAAAKALQAKAMAAATIAAAJIg+AAIAAABQABANAGAJQAHAJAMAAQAJAAAGgCQAHgDAFgEIAHALQgFAFgJADQgIAEgMAAQgUAAgLgOgAoxgZQgFAHgCALIAAABIAsAAIAAgDQAAgKgFgHQgGgGgLAAQgJAAgGAHgAKTAxIAAiHIASAAIAACHgAF9AxIAAg6QAAgMgFgFQgFgGgKAAQgHAAgGADQgGAEgEAGIAABEIgRAAIAAiHIARAAIAAA2QAGgGAHgEQAGgEAKAAQAPAAAIAJQAIAJAAATIAAA6gACtAxIAAg6QAAgMgGgGQgEgFgKAAQgIAAgGAEQgGADgDAGIAABEIgSAAIAAhdIAQAAIABAOQAFgIAHgEQAIgEAIAAQAQAAAIAJQAJAJAAATIAAA6gABEAxIAAhdIASAAIAABdgAh4AxIAAg6QAAgMgEgGQgGgFgKAAQgHAAgGAEQgGADgDAGIAABEIgRAAIAAhdIAPAAIACAOQAEgIAHgEQAIgEAJAAQAPAAAIAJQAJAJgBATIAAA6gAjfAxIAAhdIARAAIAABdgAkLAxIAAg6QAAgMgFgGQgFgFgKAAQgHAAgHAEQgFADgEAGIAABEIgRAAIAAhdIAPAAIACAOQAFgIAGgEQAIgEAJAAQAQAAAIAJQAIAJAAATIAAA6gAmFAxIAAhdIAQAAIABAOQAFgIAFgEQAGgEAJAAIADAAIADABIgDAQIgJgBQgGAAgFAEQgFADgCAGIAABCgAqkAxIAAh+IARAAIAABwIA8AAIAAAOgABEhFIAAgRIASAAIAAARgAjfhFIAAgRIARAAIAAARg");
	this.shape_14.setTransform(71.4,33.2);

	this.shape_15 = new cjs.Shape();
	this.shape_15.graphics.f("#808080").s().p("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");
	this.shape_15.setTransform(76.7,33.2);

	this.shape_16 = new cjs.Shape();
	this.shape_16.graphics.f("#808080").s().p("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");
	this.shape_16.setTransform(81.6,33.2);

	this.shape_17 = new cjs.Shape();
	this.shape_17.graphics.f("#808080").s().p("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");
	this.shape_17.setTransform(86.7,33.2);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[]}).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape_1}]},1).to({state:[{t:this.shape_2}]},1).to({state:[{t:this.shape_3}]},1).to({state:[{t:this.shape_4}]},1).to({state:[{t:this.shape_5}]},1).to({state:[{t:this.shape_6}]},1).to({state:[{t:this.shape_7}]},1).to({state:[{t:this.shape_8}]},1).to({state:[{t:this.shape_9}]},1).to({state:[{t:this.shape_10}]},1).to({state:[{t:this.shape_11}]},1).to({state:[{t:this.shape_12}]},1).to({state:[{t:this.shape_13}]},1).to({state:[{t:this.shape_14}]},1).to({state:[{t:this.shape_15}]},1).to({state:[{t:this.shape_16}]},1).to({state:[{t:this.shape_17}]},1).wait(82));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = null;


// symbols:
(lib.Symbol1 = function() {
	this.initialize();

	// Layer 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#F2F2F2").s().p("AAAAAQgHAAgHAGIgFgFQAJgGAKAAQAMAAAIAGIgFAFQgGgGgJAAg");
	this.shape.setTransform(0.1,-5.1);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#F2F2F2").s().p("AgGAHQgDgDAAgEQAAgDADgDQADgDADAAQAEAAADADQADADAAADQAAAEgDADQgDADgEAAQgDAAgDgDg");
	this.shape_1.setTransform(0.1,-3.4);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f("#F2F2F2").s().p("AAAAAQgVAAgQAOIgJgJQAUgSAaAAQAbAAAUASIgKAJQgPgOgWAAg");
	this.shape_2.setTransform(0.1,-8.1);

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.f("#F2F2F2").s().p("AAAAAQgOAAgLAKIgGgHQAOgMARAAQATAAANAMIgGAHQgLgKgPAAg");
	this.shape_3.setTransform(0.1,-6.6);

	this.shape_4 = new cjs.Shape();
	this.shape_4.graphics.f("#29ABE2").s().p("AhKBZQgLAAgGgBQgOgEgKgMQgJgMAAgPQgBgQALgNQALgNAQgDIAIAAIADAAIAAgBQgHgSAIgSQAJgQARgGQARgGARAIQAAABABAAQABAAAAAAQABgBAAAAQABgBAAgBQALgYAbgFQAbgEAUATQAWAXgJAgIgBADIADACQAfALAFAeQADAWgNASQgNAQgUAEIgOABg");
	this.shape_4.setTransform(0,-9);

	this.addChild(this.shape_4,this.shape_3,this.shape_2,this.shape_1,this.shape);
}).prototype = p = new cjs.Container();
p.nominalBounds = new cjs.Rectangle(-12.5,-18,25.2,18);

})(lib = lib||{}, images = images||{}, createjs = createjs||{});
var lib, images, createjs;